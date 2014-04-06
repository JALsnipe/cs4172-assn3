COMS W4172: 3D User Interfaces and Augmented Reality
Steven Feiner 

Josh Lieberman
jal2238
jal2238@columbia.edu
Assignment 3: Keeping Track

Date of Submission: 4/6/2014

Development Environment:
Mac OS X Version 10.9.1
LG Nexus 5 running Android version 4.4.2

Project Title: cs4172-assn3
Scene Title: arscene.unity

Directory Overview:
Assets/ - contains all project assets
Assets/_Scenes/ - contains a single scene file, SolarSystem.unity
Assets/Models/ - contains all models used
Assets/Scripts/ - contains all necessary C# script files
[more?]

Special Instructions:
None, just build and run.  App should run in landscape mode.

Instructions:
App should be straightforward.  Object controls appear on the right side of the
screen as objects are selected to be manipulated.

Missing features:
-

Bugs in Code:
Nothing that would halt compliation.

Asset Sources:
orange pumpkin:
http://www.turbosquid.com/3d-models/free-simple-pumpkin/315902

grey pumpkin:
http://www.turbosquid.com/3d-models/free-obj-mode-halloween-pumpkin/763410

better tool target (gravel):
http://www.jpl.nasa.gov/apps/images/3dtarget.pdf

main target (woodchips):

Video Demo:



---notes---

useful links:
http://monet.cs.columbia.edu/courses/csw4172/assn3-14.html

http://www.dannygoodayle.com/2013/03/01/making-your-first-project-with-unity-and-augmented-reality/
http://www.dannygoodayle.com/2013/03/04/setting-up-your-system-for-unity-android-development/

orange pumpkin:
http://www.turbosquid.com/3d-models/free-simple-pumpkin/315902

grey pumpkin:
http://www.turbosquid.com/3d-models/free-obj-mode-halloween-pumpkin/763410

better tool target (gravel):
http://www.jpl.nasa.gov/apps/images/3dtarget.pdf

main target (woodchips):

For terminal logging:
adb logcat -s Unity

true ray casting or another approach
extended tracking

Ideas:
-rotation: start with single object, and have a second trackable target.  when 2nd "do something" target is tracked, slowl rotate the selected object clockwise (or counter-clockwise).  when object is no longer tracked, stop rotation

-scaling: as the user moves futher from and closer to the object, scale the object based on the distance of the camera from the object.  have min and max scale values.

Still need to figure out translation
-take goblin city approach?
	when translation selected, have "tool" target map to the new location of an object.

like using virtualbuttons, but some may require 3 hands if i do the tap and hold approach.  try toggle?

bugs:
workspace only supports sphere
need to be able to clone objects and delete objects