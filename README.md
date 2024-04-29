# ChatWinForms

ChatWinForms is a very basic client-server messanger, that uses TcpClient and TcpServer classes for establishing connection between each other. The applications are sinple user window and server window. GUI of applications were created using WinForms.

## Installation
Clone repository, and buld the project to generate exe file. After that, to open client application, go to ChatWinForms\ChatWinForms\bin\Debug\net8.0-windows\ and execute ChatWinForms.exe. Do the same for server application: go to ChatWinForms\ServerTCPWinForms\bin\Debug\net8.0-windows\ and execute ServerTCPWinForms.exe

## Usage
1) Open a server application, choose on which port you will want to listen for connection, choose name of a server-user and add key if it's necessary. After that click "Start" button.
2) After that open one or better more client's appllications, and click "File" and after that "Connect".
3) Write Address and Port of a server that You was started before. Click "Connect".
4) After success, Connect form should be closed and message "Connected" should arrive.
5) For sending messages, type it in text box at the bottom of client's application. After that, click Enter or Send button. 
6) For stop connection from server application, You can Kick choosed user on right side of a screen, where button Kick is placed. Also all users will be disconnected from server, if "Disconnect all" button is clicked or server was stopped.
7) To stop server klick "Stop" button in servers application.

## Features
1) All event with server are logged to main text box is servers application.
2) It's possible to write to all users from server, just type and send a message from servers application.
3) It's possible to disconnected choosen users, and add new after that, or disconnect all. 
4) All newly connected users are added to panel in a right side of a server application.
5) Events while connecting and disconnecting are reported in server's application in logs, and in clients applications in message boxes.
