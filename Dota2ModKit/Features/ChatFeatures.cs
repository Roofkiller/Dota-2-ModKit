using ChatSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota2ModKit.Features {
    public class ChatFeatures {
        MainForm mf;
        IrcClient client;
        IrcUser user;
        public StringBuilder currChat = new StringBuilder();
        string lastChat = "";
        string lastUserList = "";
        string lastSpokenUser = "";
        public ChatFeatures(MainForm mf) {
            this.mf = mf;
            getUserAndClient();
            setupHooks();
            client.ConnectAsync();
            Util.CreateTimer(200, (timer) => {
                var chat = currChat.ToString();
                if (currChat.Length > 11000) {
                    chat = chat.Substring(chat.IndexOf("\n") + 1);
                    currChat = new StringBuilder(chat);
                }

                if (chat != lastChat) {
                    lastChat = chat; // we need this because the rich text box converts \r\n to \n, which screws up the comparison.
                    mf.chatViewRichTB.Text = chat;
                    var lines = mf.chatViewRichTB.Lines;
                }

                // do the user list textbox
                StringBuilder sb = new StringBuilder();
                foreach (var channel in client.Channels) {
                    if (channel.Name == "#dotacoders") {
                        foreach (var user in channel.Users) {
                            var nick = user.Nick;
                            sb.AppendLine(nick);
                        }
                        var userList = sb.ToString();
                        if (userList != lastUserList) {
                            mf.usernamesRichTB.Clear();
                            lastUserList = userList;
                            mf.usernamesRichTB.Text = userList;
                        }
                    }
                }
            });
        }

        private void setupHooks() {
            client.ConnectionComplete += (s, e) => {
                client.JoinChannel("#dotacoders");
                Debug.WriteLine("ConnectionComplete, joined channel");
            };
            client.ChannelMessageRecieved += (s, e) => {
                var msg = e.PrivateMessage.Message;
                var sender = e.PrivateMessage.User.Nick;
                displayMsg(sender, msg);
            };
            client.NetworkError += (s, e) => {
                Debug.WriteLine("Network error.");
            };
            mf.chatReconnectBtn.Click += (s, e) => {
                mf.fixButton();
                getUserAndClient();
                client.ConnectAsync();

            };
            mf.chatMsgTextBox.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    var msg = mf.chatMsgTextBox.Text;
                    mf.chatMsgTextBox.Text = "";
                    displayMsg(client.User.Nick, msg);
                    client.SendMessage(msg, "#dotacoders");

                }
            };
        }

        private void displayMsg(string sender, string msg) {
            int nickBuffer = 16;
            int spacesToAdd = nickBuffer - sender.Length - 2; // 1 is for colon, 1 for |
                                                              // for names that are too long:
            if (spacesToAdd < 0) {
                sender = sender.Substring(0, sender.Length + spacesToAdd);
            }
            StringBuilder sb = currChat;
            if (sb.Length > 0) {
                sb.Append("\n");
            }
            sb.Append(">");
            for (int i = 0; i < spacesToAdd; i++) {
                sb.Append(" ");
            }
            sb.Append(sender + ": ");
            sb.Append(msg);
            lastSpokenUser = sender;
            currChat = sb;
        }

        private void getUserAndClient() {
            if (mf.chatUsernameTextBox1.Text.Length == 0) {
                mf.chatUsernameTextBox1.Text = getRandomUsername();
            }
            if (mf.chatPasswordTextBox1.Text.Length > 0) {
                user = new IrcUser(mf.chatUsernameTextBox1.Text, mf.chatUsernameTextBox1.Text, mf.chatPasswordTextBox1.Text);
            } else {
                user = new IrcUser(mf.chatUsernameTextBox1.Text, mf.chatUsernameTextBox1.Text);
            }
            client = new IrcClient("irc.globalgamers.net", user);
        }

        private string getRandomUsername() {
            Random rand = new Random();
            return "developer" + rand.Next(100,6000);
        }
    }
}
