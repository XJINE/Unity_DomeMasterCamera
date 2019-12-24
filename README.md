# Unity_DomeMasterCamera

<img src="https://github.com/XJINE/Unity_DomeMasterCamera/blob/master/Screenshot.png" width="100%" height="auto" />

DomeMasterCamera makes DomeMaster image with smallest camera sets, without Cubemap.
So the performance is more better than [DomeMaster image effect](https://github.com/XJINE/Unity_DomeMaster).

## Import to Your Project

You can import this asset from UnityPackage.

- [DomeMasterCamera.unitypackage](https://github.com/XJINE/Unity_DomeMasterCamera/blob/master/DomeMasterCamera.unitypackage)

## How to Use

 1. Add ``DomeCamera`` into your scene and it will render 4-way textures into each material.
 2. Add ``DomeMasterCamera`` into your scene. It has 4 meshes to make a DomeMaster image.
 3. ``DomeMasterCamera`` has also a camera, it will capture the 4 meshes. The result is DomeMaster image.

Layer settings are important. Set some layer and culling mask settings to hide a DomeMasterMesh.

## Difference

There are some differences from [DomeMaster image effect](https://github.com/XJINE/Unity_DomeMaster).

- DomeMasterCamera cannot change the FOV.
- DomeMasterCamera needs low resolution image than DomeMaster effect.
    - DomeMasterCamera makes 4 images to make a DomeMaster image.
    - DomeMaster effect makes 5 images + 1 blank image to make a DomeMaster(Cubemap) image.
- DomeMasterCamera is able to use any resolution.
    - DomeMaster effect must use the Power-of-2 resolution image to make a Cubemap image. 
- DomeMaster effect is more simple than DomeMasterCamera.

### Performance

DomeMasterCamera is about x1.5 faster than DomeMaster effect in popular cases.
Because DomeMaster effect needs to render 6 images (5 + 1 blank image), and bend the images with FragmentShader.
So the effect takes more cost when making a more high resolution image.

## Reference

- [iDome: Immersive gaming with the Unity game engine](http://paulbourke.net/papers/cgat09b/) : Original Paper.
- [Creating interactive dome contents with Unity](https://www.orihalcon.co.jp/news/unity-dome-kit/)