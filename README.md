# STRAFTAT Stream Safety

This adds a 'streamer mode' to STRAFTAT to save you from Twitch TOS or similiar.

This is configurable and allows you to choose how much you want to censor the game.

- censor words - ON BY DEFAULT
    - Replaces words found in the badWords file with *
    - This is a very simple regex replace operation EX: Knight becomes K***ht
    - This is not guaranteed to catch everything but is the least disruptive option
- Privacy Mode - ON BY DEFAULT
    - When hosting a lobby this will hide your friend id, lobby id, and friends list
- Completely Disable Chat - DISABLED BY DEFAULT
    - Neither your own messages, or the other players messages will display
    - You can still however send messages incase you need to communicate something, **you** just won't see them
- Proxy Chat - DISABLED BY DEFAULT
    - This option launches an external program that the chat text is routed to
    - This allows you to display the external program on your second monitor
    - You can read the game chat, but your twitch stream will not be able to see it
    - Messages will still display on your game but the name and content will be replaced with "Name" and "Sent a message"
    - As you would assume, this option makes the most significant changes but is the most foolproof without completely disabling chat.
- Remove Foreign Icons - DISABLED BY DEFAULT
    - Turn this on if you're worried about being matched with people with TOS breaking pfps

 Default settings:
 (chat proxy false, remove foreign icons false, privacy mode true censor chat true)
![Default](https://github.com/user-attachments/assets/8e72b26e-691c-4feb-b2cb-ff46ed8b72bc)

Proxy mode:
(chat proxy true, remove foreign icons true, privacy mode true, censor chat false)

This is the 'STRAFTAT Chat Proxy' that pops up:
![chatProxy](https://github.com/user-attachments/assets/c14de6c8-5a83-41a9-b5f8-632ac32b428b)

This is what messages in game look like (Icons are not present because remove foreign icons is true in config):
![proxiedMessages](https://github.com/user-attachments/assets/21426c5e-ab8b-4467-93e5-cfd82ef3640c)

This is what messages in the STRAFTAT Chat Proxy window look like:
![image](https://github.com/user-attachments/assets/1e2517e4-1cfe-49b7-b0e5-cf5cf5131e8f)

Build pipe.exe from source here -> https://github.com/Malcolm-Q/ChatPipe

Get a list of badWords in a file named badWords from a place like here https://github.com/LDNOOBW/List-of-Dirty-Naughty-Obscene-and-Otherwise-Bad-Words/blob/master/en
