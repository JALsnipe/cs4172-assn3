COMS W4172: 3D User Interfaces and Augmented Reality
Steven Feiner 

Josh Lieberman
jal2238
jal2238@columbia.edu
Assignment 3: Keeping Track

useful links:
http://monet.cs.columbia.edu/courses/csw4172/assn3-14.html

http://www.dannygoodayle.com/2013/03/01/making-your-first-project-with-unity-and-augmented-reality/
http://www.dannygoodayle.com/2013/03/04/setting-up-your-system-for-unity-android-development/

spongebob model:
http://tf3dm.com/3d-model/spongebob-62487.html

Patrick model:
http://tf3dm.com/3d-model/patrick-736.html

spongebob target:
http://yooland.org/nickelodeon-coloring-pages-nickelodeon-spongebob-coloring-page-printable-pages/

mario target:
http://www.siliconera.com/postgallery/?p_gal=75227|0

toolbar target:
http://creativejs.com/2012/03/augmented-reality/

better tool target (gravel):
http://www.jpl.nasa.gov/apps/images/3dtarget.pdf

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