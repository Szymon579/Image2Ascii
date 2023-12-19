# Image2Ascii
Creating ASCII art from images

## User Interface
![Alt text](/../master/ui.png?raw=true "User Interface")
- **LOAD IMAGE** opens the file dialog
- **WRITE TO FILE** redirects the output stream to a file created in the same directory as an original image.
- **SCALE** sets the scale of the output image. Setting the scale to N generates output where one char represents N*N pixels.
- **GETPIXEL** performs the conversion using C# `getPixel()` function
- **BMPDATA** performs the conversion operating on raw BMP data which makes it significantly faster than `getPixel()`.

## ASCII generated with scale 5
![Alt text](/../master/mustang_1-5.png?raw=true "Generated with scale 5")

## ASCII generated with scale 10
![Alt text](/../master/mustang_1-10.png?raw=true "Generated with scale 10")
