/*

The MIT License (MIT)
Copyright (c) 2016 Lentil Sun

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

using System;
using INFITF;
using MECMOD;
using System.Runtime.InteropServices;

namespace Core
{
    public class iPartDoc
    {
        private PartDocument opartdoc;
        public iPartDoc()
        {
            Application CATIA;
            try
            {
                CATIA = (Application)Marshal.GetActiveObject("CATIA.Application");
            }
            catch
            {
                Type oType = Type.GetTypeFromProgID("CATIA.Application");
                CATIA = (Application)Activator.CreateInstance(oType);
                CATIA.Visible = true;
            }
            opartdoc = ((PartDocument)CATIA.Documents.Add("Part"));
        }
        public PartDocument Consult()
        {
            return opartdoc;
        }
    }
}
