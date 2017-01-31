﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cupon.aspx.cs" Inherits="WebFormatoHtml.Cupon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <style type="text/css">
.barcode { 
  float:left;
  clear:both;
  padding: 0 10px; /*quiet zone*/
  overflow:auto;
  height:0.5in; /*size*/ 
}
.right { float:right; }
.barcode + * { clear:both; }
.barcode div { 
  float:left;
  height: 0.35in; /*size*/
}
.barcode .bar1 { border-left:0px solid black; }
.barcode .bar2 { border-left:1px solid black; }
.barcode .bar3 { border-left:2px solid black; }
.barcode .bar4 { border-left:3px solid black; }
.barcode .space0 { margin-right:0 }
.barcode .space1 { margin-right:1px }
.barcode .space2 { margin-right:2px }
.barcode .space3 { margin-right:3px }
.barcode .space4 { margin-right:4px }
.barcode label { 
  clear:both; 
  display:block; 
  text-align:center;  
  font: 3.125in/100% helvetica; /*size*/
  font-weight:bold;
}
/*** bigger ******************************************/
.barcode2 { 
  float:left;
  clear:both;
  padding: 0 10px; /*quiet zone*/
  overflow:auto;
  height:1.5in; /*size*/ 
}
.barcode2 + * { clear:both; }
.barcode2 div { 
  float:left;
  height: 0.7in; /*size*/
}
.barcode2 .bar1 { border-left:2px solid black; }
.barcode2 .bar2 { border-left:4px solid black; }
.barcode2 .bar3 { border-left:6px solid black; }
.barcode2 .bar4 { border-left:8px solid black; }
.barcode2 .space0 { margin-right:0 }
.barcode2 .space1 { margin-right:1px }
.barcode2 .space2 { margin-right:2px }
.barcode2 .space3 { margin-right:5px }
.barcode2 .space4 { margin-right:7px }
.barcode2 label { 
  clear:both; 
  display:block; 
  text-align:center;  
  font: 0.200in/100% helvetica; /*size*/
  /*font-weight:bold;*/
  font-family:Tahoma;
}
</style>

 <script type="text/javascript">       
        (function () {
            if (!exports) var exports = window;
            var BARS = [212222, 222122, 222221, 121223, 121322, 131222, 122213, 122312, 132212, 221213, 221312, 231212, 112232, 122132, 122231, 113222, 123122, 123221, 223211, 221132, 221231, 213212, 223112, 312131, 311222, 321122, 321221, 312212, 322112, 322211, 212123, 212321, 232121, 111323, 131123, 131321, 112313, 132113, 132311, 211313, 231113, 231311, 112133, 112331, 132131, 113123, 113321, 133121, 313121, 211331, 231131, 213113, 213311, 213131, 311123, 311321, 331121, 312113, 312311, 332111, 314111, 221411, 431111, 111224, 111422, 121124, 121421, 141122, 141221, 112214, 112412, 122114, 122411, 142112, 142211, 241211, 221114, 413111, 241112, 134111, 111242, 121142, 121241, 114212, 124112, 124211, 411212, 421112, 421211, 212141, 214121, 412121, 111143, 111341, 131141, 114113, 114311, 411113, 411311, 113141, 114131, 311141, 411131, 211412, 211214, 211232, 23311120]
              , START_BASE = 38
              , STOP = 106 //BARS[STOP]==23311120 (manually added a zero at the end)
            ;

            // TODO: hoe met een array van getallen om te gaan
            function code128(code, barcodeType) {
                if (arguments.length < 2) barcodeType = code128Detect(code);
                if (barcodeType == 'C' && code.length % 2 == 1) code = '0' + code;
                var a = parseBarcode(code, barcodeType);
                return bar2html(a.join('')) + '<label>' + code + '</label>';
            }

            function bar2html(s) {
                for (var pos = 0, sb = []; pos < s.length; pos += 2) {
                    sb.push('<div class="bar' + s.charAt(pos) + ' space' + s.charAt(pos + 1) + '"></div>');
                }
                return sb.join('');
            }

            function code128Detect(code) {
                if (/^[0-9]+$/.test(code)) return 'C';
                if (/[a-z]/.test(code)) return 'B';
                return 'A';
            }

            function parseBarcode(barcode, barcodeType) {
                var bars = [];
                bars.add = function (nr) {
                    var nrCode = BARS[nr];
                    this.check = this.length == 0 ? nr : this.check + nr * this.length;
                    this.push(nrCode || ("UNDEFINED: " + nr + "->" + nrCode));
                };
                bars.add(START_BASE + barcodeType.charCodeAt(0));
                for (var i = 0; i < barcode.length; i++) {
                    var code = barcodeType == 'C' ? +barcode.substr(i++, 2) : barcode.charCodeAt(i);
                    converted = fromType[barcodeType](code);
                    if (isNaN(converted) || converted < 0 || converted > 106) throw new Error("Unrecognized character (" + code + ") at position " + i + " in code '" + barcode + "'.");
                    bars.add(converted);
                }
                bars.push(BARS[bars.check % 103], BARS[STOP]);
                return bars;
            }
            var fromType = {
                A: function (charCode) {
                    if (charCode >= 0 && charCode < 32) return charCode + 64;
                    if (charCode >= 32 && charCode < 96) return charCode - 32;
                    return charCode;
                },
                B: function (charCode) {
                    if (charCode >= 32 && charCode < 128) return charCode - 32;
                    return charCode;
                },
                C: function (charCode) {
                    return charCode;
                }
            };

            //--| Export
            exports.code128 = code128;
        })();
    </script>
 	 <script type="text/javascript">

        function encode() {
            var strValue = "51C794DDAC4FA9E"; //document.getElementById("barcode_input").value;
            var strBarcodeHTML = code128(strValue);
            document.getElementById("barcode").innerHTML = strBarcodeHTML;
        }
    </script>
</head>
<body style="margin:0px; font-family:Arial, Helvetica, sans-serif;" onload="encode()">    
    <div style="position:relative">
        <img alt="" src="http://10.10.10.208/web_cupon/cupon.jpg" width="1000" />
        <div style="position:absolute; top:50px; left:780px;">
            <label style="font-size:40px;font-weight:bold">100.00</label>
        </div>
        <div style="position:absolute; top:250px; left:270px;">
            <label style="font-size:18px;font-weight:bold">TREINTA Y 00/100 SOLES</label>
        </div>
        
    </div>
   <div style="position:absolute; top:160px; left:640px; text-align:center; vertical-align:top; font-family: Verdana, Geneva, sans-serif; width: 427px;">
            <div class="barcode2"  id="barcode"></div><br /><br />
        </div>
</body>
</html>
