# SkyHighRemote
A Blazor PWA to control Sky HD Boxes.

What began as an excuse to learn some Blazor actually turned into a useful application. SkyHighRemote allows you to control a Sky HD PVR on your home network.  Particularly useful if you are splitting the HDMI signal to show the image on more than 1 display and don't want to add a magic eye and/or 2nd remote.

The application can be installed on your device as a Progressive Web App.  You still need the Server side running but installing it on your mobile or similar makes it work more like a regular mobile app.

I run this on IOS14 in Firefox with the server side hosted on a Ubuntu 18.04 server behind Nginx.

You can store your Sky PIN in the application as well as send text to the box.

Functionality should be pretty self explanatory from the screenshots at the end of this readme.

The application uses a number of other existing Open Source modules, in particular (and extra thanks to) :

<p>ParkSquare.SkyTV : <a href="https://www.nuget.org/packages/ParkSquare.SkyTv/3.1.0" target="_blank" alt="Parksquare.SkyTV">https://www.nuget.org/packages/ParkSquare.SkyTv/3.1.0</a></p>
<p>Dalhundal/Sky-Remote : <a href="https://github.com/dalhundal/sky-remote" target="_blank" alt="Dalhundal/Sky-Remote">https://github.com/dalhundal/sky-remote</a></p>

## Installation
- Requires .Net Core 3.1 on the server or your development environment.  Not tested with any other version.
- Requires Node.js on the server or your development environment.
- To run locally, clone this repo to your local machine, open in Visual Studio, and run.

### Example Installation on Ubuntu 18.04 with Nginx:  

Install and update Ubuntu

    apt update && apt upgrade

Install Nginx and Node.js

    apt install nginx nodejs
    systemctl start nginx
    systemctl enable nginx
    
Download and install .NET Core (more info here: https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)

    wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    
    sudo apt-get update; \
    sudo apt-get install -y apt-transport-https && \
    sudo apt-get update && \
    sudo apt-get install -y dotnet-sdk-3.13.1

Clone the SkyHighRemote repository

    git clone https://github.com/waseemali-S4TC/SkyHighRemote.git

Build and publish the app (run these commands in the directory that you cloned the repository into)
    
    dotnet build
    dotnet publish

Make a directory in the web root and copy the published files there

    mkdir /var/www/SkyHighRemote
    cp -r ./SkyHighRemote/SkyHighRemote/Server/bin/Release/netcoreapp3.1/publish/* /var/www/SkyHighRemote/

Edit the Nginx configuration file for port redirection

    vim /etc/nginx/sites-available/default

Under the 'Default server configuration' section, find the line that starts 'location / {' and within the curly braces add the following

    proxy_pass http://localhost:5000;
    proxy_http_version 1.1;
    proxy_set_header Upgrade $http_upgrade;
    proxy_set_header Connection keep-alive;
    proxy_set_header Host $host;
    proxy_cache_bypass $http_upgrade;
    proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
    proxy_set_header X-Forwarded-Proto $scheme;

Save the file

Test and reload Nginx

    nginx -t (tests the configuation file)
    nginx -s reload (reloaded the Nginx server)

Create a service file to run the app (this will allow it to run unattended)

    vim /etc/systemd/system/SkyHighRemote.service

Add the following text

    [Unit]
    Description=.NET Web App running on Ubuntu

    [Service]
    WorkingDirectory=/var/www/SkyHighRemote
    ExecStart=/usr/bin/dotnet SkyHighRemote.Server.dll
    Restart=always
    # Restart service after 10 seconds if the dotnet service crashes:
    RestartSec=10
    SyslogIdentifier=dotnet-SkyHighRemote
    User=root
    Environment=ASPNETCORE_ENVIRONMENT=Development

    [Install]
    WantedBy=multi-user.target


Save the file

Start and enable the service

    systemctl start SkyHighRemote.service
    systemctl enable SkyHighRemote.service

Optional/Recommended: If you're enabling the firewall (UFW), add the following rules

    ufw allow ssh
    ufw allow http
    ufw allow https
    ufw allow proto udp from [your subnet e.g. 192.168.1.0/24] to any port 10000:59999


## FAQ
Any questions about the application and deployment will be answered here.

1.  Why is there a client and server side version number on the configuration page?

A 'quirk' of PWA's is that some browsers (cough, Safari Mobile) don't update themselves when the application changes server side.  This means that the client side and server side application can become out of sync with each other. To rectify this I have added a version check which flags up a disparity on the configuration page of the application.  Annoyingly, Safari sometimes ***STILL*** won't update so you have to clear your browser cache to rectify that.

2. Why do I need node.js?

I am using an existing node module to do the network calls to the box.  This is called from .Net Core.  An alternative would have been to figure out this part myself using some kind of packet sniffing (or my currently non-existent node.js porting skills!).  Once I got the node.js module working in .Net Core and saw how fast it was it made that arduous task redundant.


<img src="https://raw.githubusercontent.com/waseemali-S4TC/SkyHighRemote/master/SkyHighRemote/Client/wwwroot/images/Screen2.jpg" width="310px" height="auto" style="border: 1px solid #F5F5F5;">
<img src="https://raw.githubusercontent.com/waseemali-S4TC/SkyHighRemote/master/SkyHighRemote/Client/wwwroot/images/Screen1.jpg" width="300px" height="auto" style="border: 1px solid #F5F5F5;">


