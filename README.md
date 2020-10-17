# kawakudari-gdiplus

This project implements part of the [std15.h](https://github.com/IchigoJam/c4ij/blob/master/src/std15.h) API (from [c4ij](https://github.com/IchigoJam/c4ij)) with [GDI+](https://docs.microsoft.com/dotnet/api/system.drawing)(System.Drawing), and [Kawakudari Game](https://ichigojam.github.io/print/en/KAWAKUDARI.html) on top of it.

It will allow programming for [IchigoJam](https://ichigojam.net/index-en.html)-like targets that display [IchigoJam FONT](https://mitsuji.github.io/ichigojam-font.json/) on screen using a C# programming language.
```
    private void OnSetup ()
    {
        std15 = new Std15(512,384,32,24);
        rnd = new Random();
        frame = 0;
        x = 15;
        running = true;
    }

    private void OnUpdate ()
    {
        if (!running) return;
        if (frame % 5 == 0) {
            std15.Locate(x,5);
            std15.Putc('0');
            std15.Locate(rnd.Next(0,32),23);
            std15.Putc('*');
            std15.Scroll(Std15.Direction.Up);
            if (std15.Scr(x,5) != '\0') {
                std15.Locate(0,23);
                std15.Putstr("Game Over...");
                std15.Putnum((int)frame);
                running = false;
            }
        }
        frame++;
    }

    private void OnKeyDown (object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Left)  x--;
        if (e.KeyCode == Keys.Right) x++;
    }

```

## Prerequisite

### Windows

* [Download](https://dotnet.microsoft.com/download/dotnet-framework) and install .Net Framework.
(In most cases, it is pre-installed.)


### Linux

* [Download](https://www.mono-project.com/download/stable/) and install mono suitable for your environment.
* [Download](https://www.mono-project.com/docs/gui/libgdiplus/) and install libgdiplus suitable for your environment.(In most cases, the distribution provides the package.)


### macOS

GDI+ and its ports are seemed to not provided for recent versions of macOS.





## How to use

### Windows

To build it
```
> csc Kawakudari.cs IchigoJam.cs
```
Or with full path to compiler,
```
> \Windows\Microsoft.NET\Framework64\v3.5\csc.exe Kawakudari.cs IchigoJam.cs
```

To run it
```
> Kawakudari.exe
```


### Linux

To build it
```
$ mcs -r:System.Windows.Forms.dll -r:System.Drawing.dll Kawakudari.cs IchigoJam.cs
```

To run it
```
$ mono Kawakudari.exe
```



## License
[![Creative Commons License](https://i.creativecommons.org/l/by/4.0/88x31.png)](http://creativecommons.org/licenses/by/4.0/)
[CC BY](https://creativecommons.org/licenses/by/4.0/) [mitsuji.org](https://mitsuji.org)

This work is licensed under a [Creative Commons Attribution 4.0 International License](http://creativecommons.org/licenses/by/4.0/).
