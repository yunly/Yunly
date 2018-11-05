using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Yunly.Learning.DesignPattern
{
    public class Mediator
    {
        public static void testRun()
        {
            var admin = new Administrator { userName = "Admin Zack" };

            var chat = admin.CreateChatGroup();

            var jack = new CommandMember { userName = "Jack" };
            var mike = new CommandMember { userName = "Mike" };

            var mary = new CommandMember { userName = "Mary" };



            var yuan = new VipMember { userName = "Yuan" };
            var xia = new VipMember { userName = "Xia" };


            jack.RegisterChat(chat);
            mike.RegisterChat(chat);
            mary.RegisterChat(chat);

            yuan.RegisterChat(chat);
            xia.RegisterChat(chat);



            jack.sendMessage(mike, "Hello mike, nice to meet you.");
            jack.sendImage(mary, "Hello Marry, it's my picture.");

            yuan.sendImage(admin, "My dear, it's me.");
            xia.sendImage(admin, "My dear, it's me.");


            admin.sendToAll("Haha, beautifual.");
        }
    }

    public abstract class ChatRoom
    {
        public abstract void registor(params Member[] members);

        public abstract void sendMessage(Member sender, Member receiver, string text);
        public abstract void sendImage(Member sender, Member receiver, string Image);

        public abstract void setAdmin(Administrator admin);
        public abstract void sendToAll(Member admin, string message);
    }

    public class ChatGroup : ChatRoom
    {

        Administrator admin = null;

        public override void setAdmin(Administrator admin)
        {
            this.admin = admin;
        }

        List<Member> chatMembers = new List<Member>();


        public override void registor(params Member[]  members)
        {
            foreach (var member in members)
            {
                this.sendToAll(admin, $"welcome {member}");
                chatMembers.Add(member);
            }

            
        }



        public override void sendImage(Member sender, Member receiver, string Image)
        {
            if (sender is CommandMember)
                admin.sendMessage(sender, "You can't send a image message.");
            else
                receiver.receiveImage(sender, Image);                
        }

        public override void sendMessage(Member sender, Member receiver, string text)
        {
            receiver.receiveMessage(sender, text);
        }

        public override void sendToAll(Member admin, string message)
        {
            if (admin is Administrator)
                foreach (var member in chatMembers)
                {
                    if (!(member is Administrator))
                        member.receiveMessage(admin, message);
                }
            else
                admin.receiveMessage(this.admin, "You can't sent to All.");
        }
    }


    public abstract class Member
    {
        public string userName { get; set; }

        protected ChatRoom chatRoom;

        public void receiveImage(Member sender, string Image)
        {
            Console.WriteLine($"{this} Recieved a Image '{Image}' from {sender}");
        }

        public void receiveMessage(Member sender, string text)
        {
            Console.WriteLine($"{this} Recieved a Message '{text}' from {sender}");
        }

        public void sendImage(Member receiver, string Image)
        {
            Console.WriteLine($"{this} send a Image '{Image}' to {receiver}");
            chatRoom.sendImage(this, receiver, Image);
        }


        public void sendMessage(Member receiver, string text)
        {
            Console.WriteLine($"{this} send a Message '{text}' to {receiver}");
            chatRoom.sendMessage(this, receiver, text);
        }

        public override string ToString()
        {
            return userName;
        }

        public void RegisterChat(ChatRoom chatRoom)
        {
            this.chatRoom = chatRoom as ChatGroup;
            chatRoom.registor(this);

        }
        
    }

    public class VipMember : Member
    {


    


    }


    public class CommandMember : Member
    {




    }

    public class Administrator : Member
    {


        public ChatRoom CreateChatGroup()
        {
            chatRoom = new ChatGroup();

            chatRoom.setAdmin(this);         
            return chatRoom;
        }


        public void sendToAll(string message)
        {
            chatRoom.sendToAll(this, message);
        }
    }
}
