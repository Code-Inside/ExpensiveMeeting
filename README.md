# ExpensiveMeeting

App for calculating meeting costs. Just for fun. 

__[Download on Windows Store](https://www.microsoft.com/store/apps/9NBLGGH5PVW9)__

## Building

Windows App:
[![Build status](https://ci.appveyor.com/api/projects/status/plx7xfqx472mfs5u/branch/master?svg=true)](https://ci.appveyor.com/project/robertmuehsig/expensivemeeting/branch/master)

## Submit to Store

In a closed source project the store certificate could be checked in - but in the open this would be pretty dumb. So to create a new version for the store do this:

* Project - Store - Create App Package
* Login
* Set new version number (maybe this information get lost on the last step)
* Build
* Upload .appxupload
* Discard changes on the .csproj and never checkin the Store.pfx
* Done.
