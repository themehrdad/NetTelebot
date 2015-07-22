# NetTelebot
Telegram bot API implementation on .NET framework

# About
Do you want to create a smart automated bot on Telegram App? If you plan to write the logic using .NET framework, this tool might help you.

# Usage
After creating your own bot on [Telegram](https://core.telegram.org/bots/), you need to add a reference to "nettelebot" library.

All you need to do is to create an instance of TelegramBotClient class.

```C#
var botClient = new TelegramBotClient() { Token = "[YOUR_BOT_TOKEN]" };
```

Now you may send messages or even photos using methods in this class:

```C#
botClient.SendMessage(Chat_Id, "Hello!");
```

Or even you may listen for incoming messages from uses:

```C#
botClient.UpdatesReceived += botClient_UpdatesReceived;
private void botClient_UpdatesReceived(object sender, TelegramUpdateEventArgs e)
{
   var botClient = (TelegramBotClient)sender;
   foreach (var item in e.Updates)
   {
     if (item.Message.Text != null)
       tbc.SendMessage(item.Message.Chat.Id, item.Message.Text);
   }
}
```

# Documentation

Look at the [Wiki](https://github.com/themehrdad/NetTelebot/wiki/Documentation)
