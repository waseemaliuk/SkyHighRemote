# SkyHighRemote
A Blazor PWA to control Sky HD Boxes.

What began as an excuse to learn some Blazor actually turned into a useful application. SkyHighRemote allows you to control a Sky HD PVR on your home network.  Particularly useful if you are splitting the HDMI signal to show the image on more than 1 display and don't want to add a magic eye and/or 2nd remote.

The application can be installed on your device as a Progressive Web App.  You still need the Server side running but installing it on your mobile or similar makes it work more like a regular mobile app.

I run this on IOS14 in Firefox with the server side hosted on a Raspberry PI behind Nginx.

You can store your Sky PIN in the application as well as send text to the box.

Functionality should be pretty self explanatory from the screenshots at the end of this readme.

The application uses a number of other existing Open Source modules, in particular :

<p>ParkSquare.SkyTV : <a href="https://www.nuget.org/packages/ParkSquare.SkyTv/3.1.0" target="_blank" alt="Parksquare.SkyTV">https://www.nuget.org/packages/ParkSquare.SkyTv/3.1.0</a></p>
<p>Dalhundal/Sky-Remote : <a href="https://github.com/dalhundal/sky-remote" target="_blank" alt="Dalhundal/Sky-Remote">https://github.com/dalhundal/sky-remote</a></p>

## Installation
- Requires .Net Core 3.1 on the server or your development environment.  Not tested with any other version.
- Requires Node.js on the server or your development environment.

- Clone this repo to your local machine, open in Visual Studio, and run.

## FAQ
Any questions about the application and deployment will be answered here.
