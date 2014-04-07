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
jal2238-csw4172-assn3-written.pdf - written desription
targets/ - folder containing printable image targets
Assets/ - contains all project assets
Assets/_Scenes/ - contains a single scene file, SolarSystem.unity
Assets/Models/ - contains all models used
Assets/Scripts/ - contains all necessary C# script files
Assets/Qualcomm Augmented Reality - AR SDK

Special Instructions:
None, just build and run.  App should run in landscape mode.

Preparing Targets:
Just print the Ground target (gravel) and the Main target (Woodchips) located
in the /targets/ folder in my project directory.  Do not scale images to fit-
to-the-page, print them at their current size.

Video Demo:
https://www.youtube.com/watch?v=wMrqpi-RJHI

App Instructions:
App should be straightforward.  Object controls appear on the right side of the
screen as objects are selected to be manipulated.

Missing features:
-Delete works for all objects except Cube.
-Cube and sphere object manipulation linked.
-Workspace only supports sphere.
-Can clone objects, but can't manipulate them.
-Selection textures work in Play Mode but not on Android build (that's why you see pink).

Bugs in Code:
Nothing that would halt compliation.

Asset Sources:
orange pumpkin:
http://www.turbosquid.com/3d-models/free-simple-pumpkin/315902

grey pumpkin:
http://www.turbosquid.com/3d-models/free-obj-mode-halloween-pumpkin/763410

Ground target (gravel):
http://www.jpl.nasa.gov/apps/images/3dtarget.pdf
(local path: targets/gravel_tool.png)

Main target (Woodchips):
https://developer.vuforia.com/sites/default/files/sample-apps/targets/imagetargets_targets.pdf
(local path: targets/chipsc.png)

Code Sources:
I used code snippets from these pages to help facilitate object selection, the workspace, and translation:
http://answers.unity3d.com/questions/297066/drag-object-not-working-in-vuforia-.html
https://developer.vuforia.com/forum/unity-3-extension-technical-discussion/how-add-touch-listener-3d-object-unity
https://developer.vuforia.com/forum/faq/unity-how-can-i-dynamically-attach-my-3d-model-image-target

Written Description Sources:
I used these written sources to help me look up 3D object manipulation techniques and terminology:
-Class slides
-D. Bowman, E. Kruijff, J. LaViola Jr., and I. Poupyrev. 3D User Interfaces: Theory and Practice. Addison-Wesley, Boston, 2005, ISBN 0-201-75867-9.
-http://citeseerx.ist.psu.edu/viewdoc/download?doi=10.1.1.126.2857&rep=rep1&type=pdf