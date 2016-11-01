#pragma strict

public static class ColorExtensions {
    public static function ParseColor (col : String) : Color {
        //Takes strings formatted with numbers and no spaces before or after the commas:
        // "1.0,1.0,.35,1.0"
        var strings = col.Split(","[0] );
 
        var output : Color;
        for (var i = 0; i < 4; i++) {
            output[i] = System.Single.Parse(strings[i]);
        }
        return output;
    }
    }