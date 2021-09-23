using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Drawing.Drawing2D;

namespace Simulador_Assembler
{
    delegate void Funcion(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault);
    public static class ManejoTexto
    {
        public static List<string> ObtenerPalabras(string texto)
        {
            List<string> palabras = new List<string>();

            //char last = texto[0];
            string palabra = "";

            texto = texto.Replace("\r", " ");
            texto = texto.Replace("\t", " ");

            for (int i = 0; i < texto.Length; i++)
            {
                if ((texto[i] == '\n' || texto[i] == ' ') || i == texto.Length - 1)
                {
                    if (i == texto.Length - 1)
                        palabra += texto[i];

                    palabras.Add(palabra);
                    palabra = "";
                    continue;
                }
                if (texto[i] == '"')
                {
                    do
                    {
                        palabra += texto[i];
                        i++;
                        if (i == texto.Length - 1)
                        { palabra += texto[i]; palabras.Add(palabra); break; }
                    } while (!(texto[i] == '"' || texto[i] == '\n'));
                    palabra += texto[i];
                    //palabras.Add(palabra);
                    continue;
                }
                if (texto[i] == ';')
                {
                    palabras.Add(palabra);
                    palabra = "";
                    do
                    {
                        palabra += texto[i];
                        i++;
                        if (i == texto.Length - 1)
                            break;
                    } while (!(texto[i] == '\n'));
                    palabras.Add(palabra);
                    palabra = "";
                    continue;
                }

                palabra += texto[i];
            }

            palabras.RemoveAll(x => x == "");
            palabras.RemoveAll(x => x == "\n");
            palabras.RemoveAll(x => x[0] == ';');

            for (int i = 0; i < palabras.Count; i++)
                if (palabras[i][0] != '"')
                {
                    palabras[i] = palabras[i].Replace(" ", "");
                    palabras[i] = palabras[i].Replace(",", "");
                    palabras[i] = palabras[i].Replace(";", "");
                }
            palabras.RemoveAll(x => x == "");
            palabras.RemoveAll(x => x == "#region");
            palabras.RemoveAll(x => x == "#endregion");
            palabras.RemoveAll(x => x == "\n");
            palabras.RemoveAll(x => x[0] == ';');

            return palabras;
        }
        public static List<KeyValuePair<int, int>> ObtenerLineas(string texto)
        {
            List<KeyValuePair<int, int>> ans = new List<KeyValuePair<int, int>>();
            int length = 0, start = 0;
            for (int i = 0; i < texto.Length; i++)
            {
                length++;
                if (texto[i] == '\n' || i == texto.Length - 1)
                {
                    if (i == texto.Length - 1)
                        length++;
                    ans.Add(new KeyValuePair<int, int>(start, length - 1));
                    start = i + 1;
                    length = 0;
                }
            }
            return ans;
        }
        public static void SelectInTextBox(int start, int length, FastColoredTextBox txt)
        {
            ShortcutStyle scst = new ShortcutStyle(Pens.Maroon);
        }
        public static void SelectInTextBox(string FullText, string text, FastColoredTextBox txt)
        {
            //txt.Focus();
            //for (int i = 0; i + text.Length < FullText.Length; i++)
            //{
            //    if (FullText.Substring(i, text.Length) == text)
            //    { txt.Select(i, text.Length); return; }
            //}

            //txt.Select(0, 0);
        }
    }
    public class Instruccion
    {
        public string nombre { get; set; }
        public byte terminos { get; set; }
        public byte nStart { get; set; }
        public byte nLast { get; set; }
        public byte opciones { get; set; }
        public Instruccion(string nombre, byte terminos, byte nStart, byte nLast, byte opciones)
        {
            this.nombre = nombre;
            this.terminos = terminos;
            this.nStart = nStart;
            this.nLast = nLast;
            this.opciones = opciones;
        }
    }
    public class ValidacionSintactica
    {
        public string istructionSet { get; set; }

        public List<Instruccion> instrucciones { get; set; }

        public ValidacionSintactica()
        {
            instrucciones = new List<Instruccion>();
            instrucciones.Add(new Instruccion("MOV" , 2,   1,  12, 12));
            instrucciones.Add(new Instruccion("XCH",  2,  13,  24, 12));
            
            instrucciones.Add(new Instruccion("ADD", 2,  25,  36, 12));
            instrucciones.Add(new Instruccion("SUB", 2,  37,  48, 12));
            instrucciones.Add(new Instruccion("MUL", 2,  49,  60, 12));
            instrucciones.Add(new Instruccion("DIV", 2,  61,  72, 12));
            instrucciones.Add(new Instruccion("MOD", 2,  73,  84, 12));

            
            instrucciones.Add(new Instruccion("AND", 2,  85,  96, 12));
            instrucciones.Add(new Instruccion("OR",  2,  97, 108, 12));
            instrucciones.Add(new Instruccion("XOR", 2, 109, 120, 12));
            instrucciones.Add(new Instruccion("SHL", 2, 121, 132, 12));
            instrucciones.Add(new Instruccion("SHR", 2, 133, 144, 12));
            instrucciones.Add(new Instruccion("CMP", 2, 145, 156, 12));
            instrucciones.Add(new Instruccion("MAJ", 2, 157, 168, 12));
            instrucciones.Add(new Instruccion("MIN", 2, 169, 180, 4));
            
            instrucciones.Add(new Instruccion("OBIT",2, 181, 192, 12));
            instrucciones.Add(new Instruccion("IBIT",2, 193, 204, 4));

            instrucciones.Add(new Instruccion("SETZ",1, 205, 208, 4));
            instrucciones.Add(new Instruccion("SETC",1, 209, 212, 4));
            instrucciones.Add(new Instruccion("SETI",1, 213, 216, 4));

            instrucciones.Add(new Instruccion("PUSH", 1, 217, 220,  4));
            instrucciones.Add(new Instruccion("POP" , 1, 221, 223,  3));

            instrucciones.Add(new Instruccion("NOT" , 1, 224, 226,  3));
            instrucciones.Add(new Instruccion("NEG", 1,  227, 229,  3));
            instrucciones.Add(new Instruccion("INC",  1, 230, 232,  3));
            instrucciones.Add(new Instruccion("DEC",  1, 233, 235,  3));
            instrucciones.Add(new Instruccion("SQRT", 1, 236, 238,  3));

            instrucciones.Add(new Instruccion("JMP" , 1, 239, 239,  1));
            instrucciones.Add(new Instruccion("JC"  , 1, 240, 240,  1));
            instrucciones.Add(new Instruccion("JNC" , 1, 241, 241,  1));
            instrucciones.Add(new Instruccion("JZ"  , 1, 242, 242,  1));
            instrucciones.Add(new Instruccion("JNZ" , 1, 243, 243, 1));

            instrucciones.Add(new Instruccion("JI"  , 1, 244, 244,  1));
            instrucciones.Add(new Instruccion("JNI" , 1, 245, 245,  1));

            instrucciones.Add(new Instruccion("JAT" , 1, 246, 246,  1));
            instrucciones.Add(new Instruccion("JATF", 1, 247, 247,  1));
            instrucciones.Add(new Instruccion("JAFT", 1, 248, 248,  1));
            instrucciones.Add(new Instruccion("JAF" , 1, 249, 249,  1));

            instrucciones.Add(new Instruccion("JOT" , 1, 250, 250,  1));
            instrucciones.Add(new Instruccion("JOTF", 1, 251, 251,  1));
            instrucciones.Add(new Instruccion("JOFT", 1, 252, 252,  1));
            instrucciones.Add(new Instruccion("JOF" , 1, 253, 253,  1));

            instrucciones.Add(new Instruccion("CALL", 1, 254, 254,  1));
            instrucciones.Add(new Instruccion("RET" , 0, 255, 255, 1));

            instrucciones.Add(new Instruccion("HLT" , 0,   0,   0,  1));
            instrucciones.Add(new Instruccion("DB"  , 1,   0,   0,  1));



            foreach (Instruccion i in instrucciones)
                istructionSet += i.nombre + '|';

            istructionSet += '\b';
        }

        #region Comprobaciones
        public Instruccion GetInstruccion(byte inst)
        {
            return instrucciones.Find(x => x.nStart <= inst && x.nLast >= inst);
        }
        public bool InstruccionValida(string inst)
        {
            return instrucciones.Exists(x => x.nombre == inst.ToUpper());
        }
        public byte EsTermino(string text, byte n)
        {
            byte a;
            if (EsNumero(text, out a) && n == 2)
                return 1;

            if (EsNumero(text, out a) && n == 1)
                return 0;

            if (text == "A" || text == "[A]") return 1;
            if (text == "B" || text == "[B]") return 1;
            if (text == "C" || text == "[C]") return 1;
            if (text == "D" || text == "[D]") return 1;
            if (text == "SP" || text == "[SP]") return 1;
            if (text == "IP" || text == "[IP]") return 1;

            if (text.Length >= 2)
            {
                if (text[0] == '[')
                {
                    if (EsNumero(text.Substring(1, text.Length - 2), out a))
                        return 1;
                }
                return 2;
            }
            return 0;
        }
        public bool EsNumero(string text, out byte s)
        {
            byte a = 0;
            if (byte.TryParse(text, out a))
            { s = a; return true; }

            if (text.Length >= 3)
            {
                if (text[0] == '0' && text[1] == 'x')
                { s = (byte)(Convert.ToInt32(text.Substring(2), 16) % 256); return true; }

                if (CantLetras(text) <= 1)
                {
                    if (text[0] == '0' && text[1] == 'b')
                    { s = (byte)(Convert.ToInt32(text.Substring(2), 2) % 256); return true; }
                    if (text[0] == '0' && text[1] == 'o')
                    { s = (byte)(Convert.ToInt32(text.Substring(2), 8) % 256); return true; }
                }
            }

            s = 0; return false;
        }
        int CantLetras(string text)
        {
            int cant = 0;
            foreach (char c in text)
                if (char.IsLetter(c))
                    cant++;
            return cant;
        }
        public byte CantidadTerminos(string inst)
        {
            Instruccion n = instrucciones.Find(x => x.nombre == inst.ToUpper());
            if (n != null)
                return n.terminos;
            return 255;
        }
        public byte CantidadTerminos(byte inst)
        {
            string n = GetInstruccionString(inst);
            return instrucciones.Find(x => n == x.nombre).terminos;
        }
        public byte CantidadOpciones(byte inst)
        {
            string n = GetInstruccionString(inst);
            return instrucciones.Find(x => n == x.nombre).opciones;
        }
        public string GetInstruccionString(byte inst)
        {
            return instrucciones.Find(x => x.nStart <= inst && x.nLast >= inst).nombre;
        }
        public byte GetNInstruccion(string inst)
        {
            Instruccion n = instrucciones.Find(x => x.nombre == inst.ToUpper());
            if (n != null)
                return n.nStart;

            return 255;
        }


        public bool EsOperacion(string inst)
        {
            inst = inst.Replace("\n", "");
            inst = inst.Replace("\r", "");
            inst = inst.Replace("\t", "");
            inst = inst.Replace(" ", "");

            inst = inst.ToUpper();
            

            return InstruccionValida(inst);
        }
        public bool EsNumero(string inst)
        {
            inst = inst.Replace("\n", "");
            inst = inst.Replace("\r", "");
            inst = inst.Replace("\t", "");
            inst = inst.Replace(" ", "");

            inst = inst.ToUpper();

            byte b;
            return EsNumero(inst, out b);
        }
        public bool EsDireccion(string inst)
        {
            inst = inst.Replace("\n", "");
            inst = inst.Replace("\r", "");
            inst = inst.Replace("\t", "");
            inst = inst.Replace(" ", "");
            inst = inst.Replace(",", "");

            inst = inst.ToUpper();

            if (inst.Length >= 1)
            if (inst[0] == '[' && inst[inst.Length - 1] == ']')
                return true;

            return false;
        }
        public bool EsTexto(string inst)
        {
            inst = inst.Replace("\n", "");
            inst = inst.Replace("\r", "");
            inst = inst.Replace("\t", "");
            inst = inst.Replace(" ", "");
            inst = inst.Replace(",", "");

            inst = inst.ToUpper();

            if (inst.Length >= 1)
                if (inst[0] == '\"' || inst[inst.Length - 1] == '\"')
                    return true;

            return false;
        }
        #endregion
    }
    public class Listas
    {
        public List<KeyValuePair<int, int>> lineas { get; set; }   //Marca la posicion inicial y final de cada linea
        public List<string> tempLabelSintx { get; set; }   //Guarda, al momento de analizar sintacticamente el texto las etiquetas temporales
        public List<string> LabelSintx { get; set; }      //Guarda las etiquetas declaradas

        public Dictionary<int, KeyValuePair<int, int>> Dlineas { get; set; }  //Guarda la relación, instruccion -> linea
        public Dictionary<string, byte> labels { get; set; }    //Guarda al momento de compilar, todas las etiquetas
        public List<KeyValuePair<string, byte>> tempLabel { get; set; } //Guarda las etiquetas temporales al momento de compilar
        public List<int> pos_instrucciones { get; set; } //Guarda en que posicion [i] está la instruccion i

        public Listas()
        {
            lineas = new List<KeyValuePair<int, int>>();
            tempLabelSintx = new List<string>();
            LabelSintx = new List<string>();
            pos_instrucciones = new List<int>();
            tempLabel = new List<KeyValuePair<string, byte>>();
            Dlineas = new Dictionary<int, KeyValuePair<int, int>>();
            labels = new Dictionary<string, byte>();
        }
        public void Reset()
        {
            tempLabelSintx.Clear();
            LabelSintx.Clear();
            labels.Clear();
            Dlineas.Clear();
            tempLabel.Clear();
            pos_instrucciones.Clear();
        }
        public void AgregarTerminoTemmpLabelSintx(string text)
        {
            if (text[0] == '[')
            { tempLabelSintx.Add(text.Substring(1, text.Length - 2)); return; }

            tempLabelSintx.Add(text);
        }
    }
    public class ColorSet
    {
        public Color text_regular { get; set; } //Color.White
        public Color text_commentary { get; set; }
        public Color text_instruccions { get; set; }
        public Color text_number { get; set; }
        public Color text_label { get; set; }
        public Color text_string { get; set; }

        public Color background { get; set; }
        public Color objects { get; set; }  //37, 37, 38
        public Color sub_objects { get; set; }

        public Color RAM_INST { get; set; } //135, 104, 39
        public Color RAM_IP { get; set; } //0, 122, 204
        public Color RAM_SP { get; set; } //238, 162, 54
        public Color RAM_SP_REMAIN { get; set; } //241, 188, 107 
        public Color RAM_OUT { get; set; } //Color.Gray
        public Color RAM_A { get; set; } //87, 150, 53
        public Color RAM_B { get; set; } //239, 242, 132
        public Color RAM_C { get; set; } //Color.DarkViolet
        public Color RAM_D { get; set; } //229, 20, 0
    }
    public class Assembler
    {
        ValidacionSintactica sintaxis = new ValidacionSintactica();
        Listas listas;
        byte[] REG;
        byte[] RAM;
        bool zero, carry, fault, input;
        public Assembler(Listas listas)
        {
            this.listas = listas;
            Reset();
        }
        public Assembler(Listas listas, Bitmap RAM)
        {
            this.listas = listas;
            Reset();
            for (int x = 0; x < 16; x++)
                for (int y = 0; y < 16; y++)
                    this.RAM[y * 16 + x] = RAM.GetPixel(x, y).R;
        }

        public void Reset()
        {
            REG = new byte[6];
            RAM = new byte[256];

            REG[5] = 0;
            REG[4] = 230;

            zero = false;
            carry = false;
            fault = false;
            input = false;
        }
        public bool EjecutarInstruccion(ref int start, ref int length)
        {
            Funcion op = null;
            byte inst = RAM[REG[5]];

            switch (sintaxis.GetInstruccionString(inst))
            {
                case "MOV": op = UnidadAritmeticaLogica.MOV; break;
                case "XCH": op = UnidadAritmeticaLogica.XCH; break;

                case "ADD": op = UnidadAritmeticaLogica.ADD; break;
                case "SUB": op = UnidadAritmeticaLogica.SUB; break;
                case "MUL": op = UnidadAritmeticaLogica.MUL; break;
                case "DIV": op = UnidadAritmeticaLogica.DIV; break;
                case "MOD": op = UnidadAritmeticaLogica.MOD; break;

                case "AND": op = UnidadAritmeticaLogica.AND; break;
                case "OR":  op = UnidadAritmeticaLogica.OR; break;
                case "XOR": op = UnidadAritmeticaLogica.XOR; break;
                case "SHL": op = UnidadAritmeticaLogica.SHL; break;
                case "SHR": op = UnidadAritmeticaLogica.SHR; break;

                case "OBIT": op = UnidadAritmeticaLogica.OBIT; break;
                case "IBIT": op = UnidadAritmeticaLogica.IBIT; break;

                case "SETZ": op = UnidadAritmeticaLogica.SETZ; break;
                case "SETC": op = UnidadAritmeticaLogica.SETC; break;
                case "SETI": op = UnidadAritmeticaLogica.SETI; break;

                case "CMP": op = UnidadAritmeticaLogica.CMP; break;
                case "MAJ": op = UnidadAritmeticaLogica.MAJ; break;
                case "MIN": op = UnidadAritmeticaLogica.MIN; break;

                case "PUSH": op = UnidadAritmeticaLogica.PUSH; break;
                case "POP": op = UnidadAritmeticaLogica.POP; break;

                case "NOT": op = UnidadAritmeticaLogica.NOT; break;
                case "NEG": op = UnidadAritmeticaLogica.NEG; break;

                case "INC": op = UnidadAritmeticaLogica.INC; break;
                case "DEC": op = UnidadAritmeticaLogica.DEC; break;
                case "SQRT": op = UnidadAritmeticaLogica.SQRT; break;
            }
            int cantTerms = sintaxis.CantidadTerminos(inst);
            int cantOptns = sintaxis.CantidadOpciones(inst);
            if (cantTerms == 2)  //Dos terminos
            {
                inst -= sintaxis.GetInstruccion(inst).nStart;
                switch ((inst) % 12)
                {
                    case 0: op(ref REG[RAM[REG[5] + 1]], ref REG[RAM[REG[5] + 2]], ref zero, ref carry, ref fault); break;
                    case 1: op(ref REG[RAM[REG[5] + 1]], ref RAM[RAM[REG[5] + 2]], ref zero, ref carry, ref fault); break;
                    case 2: op(ref REG[RAM[REG[5] + 1]], ref RAM[REG[RAM[REG[5] + 2]]], ref zero, ref carry, ref fault); break;
                    case 3: op(ref REG[RAM[REG[5] + 1]], ref RAM[REG[5] + 2], ref zero, ref carry, ref fault); break;

                    case 4: op(ref RAM[RAM[REG[5] + 1]], ref REG[RAM[REG[5] + 2]], ref zero, ref carry, ref fault); break;
                    case 5: op(ref RAM[RAM[REG[5] + 1]], ref RAM[RAM[REG[5] + 2]], ref zero, ref carry, ref fault); break;
                    case 6: op(ref RAM[RAM[REG[5] + 1]], ref RAM[REG[RAM[REG[5] + 2]]], ref zero, ref carry, ref fault); break;
                    case 7: op(ref RAM[RAM[REG[5] + 1]], ref RAM[REG[5] + 2], ref zero, ref carry, ref fault); break;

                    case 8: op(ref RAM[REG[RAM[REG[5] + 1]]], ref REG[RAM[REG[5] + 2]], ref zero, ref carry, ref fault); break;
                    case 9: op(ref RAM[REG[RAM[REG[5] + 1]]], ref RAM[RAM[REG[5] + 2]], ref zero, ref carry, ref fault); break;
                    case 10: op(ref RAM[REG[RAM[REG[5] + 1]]], ref RAM[REG[RAM[REG[5] + 2]]], ref zero, ref carry, ref fault); break;
                    case 11: op(ref RAM[REG[RAM[REG[5] + 1]]], ref RAM[REG[5] + 2], ref zero, ref carry, ref fault); break;
                }
                REG[5] += 3;
            }
            else if (cantTerms == 1 && cantOptns == 4)    //Un termino | 4 opciones
            {

                inst -= sintaxis.GetInstruccion(inst).nStart;
                if (op != UnidadAritmeticaLogica.PUSH)
                {
                    switch ((inst) % 4)
                    {
                        case 0: op(ref RAM[REG[4]], ref REG[RAM[REG[5] + 1]]     , ref zero, ref carry, ref input); break;
                        case 1: op(ref RAM[REG[4]], ref RAM[RAM[REG[5] + 1]]     , ref zero, ref carry, ref input); break;
                        case 2: op(ref RAM[REG[4]], ref RAM[REG[RAM[REG[5] + 1]]], ref zero, ref carry, ref input); break;
                        case 3: op(ref RAM[REG[4]], ref RAM[REG[5] + 1]          , ref zero, ref carry, ref input); break;
                    }
                }
                else
                {
                    switch ((inst) % 4)
                    {
                        case 0: op(ref RAM[REG[4]], ref REG[RAM[REG[5] + 1]], ref zero, ref carry, ref fault); break;
                        case 1: op(ref RAM[REG[4]], ref RAM[RAM[REG[5] + 1]], ref zero, ref carry, ref fault); break;
                        case 2: op(ref RAM[REG[4]], ref RAM[REG[RAM[REG[5] + 1]]], ref zero, ref carry, ref fault); break;
                        case 3: op(ref RAM[REG[4]], ref RAM[REG[5] + 1], ref zero, ref carry, ref fault); break;
                    }
                    REG[4]--;
                }
                REG[5] += 2;
            }
            else if (cantTerms == 1 && cantOptns == 3)    //Un termino | 3 opciones
            {
                inst -= sintaxis.GetInstruccion(inst).nStart;

                if (op != UnidadAritmeticaLogica.POP)
                {
                    switch ((inst) % 3)
                    {
                        case 0: op(ref REG[RAM[REG[5] + 1]], ref REG[RAM[REG[5] + 1]], ref zero, ref carry, ref fault); break;
                        case 1: op(ref RAM[RAM[REG[5] + 1]], ref RAM[RAM[REG[5] + 1]], ref zero, ref carry, ref fault); break;
                        case 2: op(ref RAM[REG[RAM[REG[5] + 1]]], ref RAM[REG[RAM[REG[5] + 1]]], ref zero, ref carry, ref fault); break;
                    }
                }
                else
                {
                    REG[4]++;
                    switch ((inst) % 3)
                    {
                        case 0: op(ref RAM[REG[4]], ref REG[RAM[REG[5] + 1]], ref zero, ref carry, ref fault); break;
                        case 1: op(ref RAM[REG[4]], ref RAM[RAM[REG[5] + 1]], ref zero, ref carry, ref fault); break;
                        case 2: op(ref RAM[REG[4]], ref RAM[REG[RAM[REG[5] + 1]]], ref zero, ref carry, ref fault); break;
                    }

                }
                REG[5] += 2;
            }
            else if (cantTerms == 1 && cantOptns == 1)  //Un termino 1 opcion || 1 terminos
            {
                switch (sintaxis.GetInstruccionString(inst))
                {
                    case "JMP": REG[5] = RAM[REG[5] + 1]; break;

                    case "JC": if (carry == true) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;
                    case "JNC": if (carry == false) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;

                    case "JZ": if (zero == true) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;
                    case "JNZ": if (zero == false) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;

                    case "JI": if (input == true) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;
                    case "JNI": if (input == false) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;

                    case "JAT": if (carry == true && zero == true) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;
                    case "JAF": if (carry == false && zero == false) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;
                    case "JATF": if (zero == true && carry == false) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;
                    case "JAFT": if (zero == false && carry == true) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;

                    case "JOT": if (carry == true || zero == true) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;
                    case "JOF": if (carry == false || zero == false) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;
                    case "JOTF": if (zero == true || carry == false) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;
                    case "JOFT": if (zero == false || carry == true) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;
                    case "JBE": if (carry == zero) REG[5] = RAM[REG[5] + 1]; else REG[5] += 2; break;

                    case "CALL": RAM[REG[4]] = (byte)(REG[5] + 2); REG[4]--; REG[5] = RAM[REG[5] + 1]; break;
                }
            }
            else if (cantTerms == 0 && cantOptns == 1)
            {
                switch (sintaxis.GetInstruccionString(inst))
                {
                    case "RET": REG[4]++; REG[5] = RAM[REG[4]]; break;
                }
            }

            if (listas.Dlineas.ContainsKey(REG[5]))
            {
                start = listas.Dlineas[REG[5]].Key;
                length = listas.Dlineas[REG[5]].Value;
            }

            if (RAM[REG[5]] == 0)
                return false;

            return !fault;
        }
        public void Input(byte value)
        {
            input = true;
            RAM[231] = value;
        }
        
        public void GraficarTodo(Graphics salida, Graphics register, Graphics ram, int basee, bool A, bool B, bool C, bool D, bool I, ColorSet colores)
        {
            Graphics g = ram;
            ///////////////////////////////////Graficar RAM
            int _A = 24, _L = 17;
            int _D = 5;
            int b = (basee == 0) ? 16 : 10;
            g.Clear(colores.objects);

            if (I)
                foreach (int i in listas.pos_instrucciones)
                    g.FillRectangle(new SolidBrush(colores.RAM_INST), ((i % 16) * 23.7f) + _D, ((i / 16) * 16.3f) + _D, _A, _L);
            
            for (int SP = REG[4] + 1; SP <= 230; SP++)
                g.FillRectangle(new SolidBrush(colores.RAM_SP_REMAIN), ((SP % 16) * 23.7f) + _D, ((SP / 16) * 16.3f) + _D, _A, _L); //SP_REMAIN

            g.FillRectangle(new SolidBrush(colores.RAM_SP), ((REG[4] % 16) * 23.7f) + _D, ((REG[4] / 16) * 16.3f) + _D, _A, _L); //SP

            for (int SP = 232; SP <= 255; SP++)
                g.FillRectangle(new SolidBrush(colores.RAM_OUT), ((SP % 16) * 23.7f) + _D, ((SP / 16) * 16.3f) + _D, _A, _L); //Output
            


            g.FillRectangle(new SolidBrush(colores.RAM_IP), ((REG[5] % 16) * 23.7f) + _D, ((REG[5] / 16) * 16.3f) + _D, _A, _L); //IP
            if (A) g.FillRectangle(new SolidBrush(colores.RAM_A), ((REG[0] % 16) * 23.7f) + _D, ((REG[0] / 16) * 16.3f) + _D, _A, _L); //A
            if (B) g.FillRectangle(new SolidBrush(colores.RAM_B), ((REG[1] % 16) * 23.7f) + _D, ((REG[1] / 16) * 16.3f) + _D, _A, _L); //B
            if (C) g.FillRectangle(new SolidBrush(colores.RAM_C), ((REG[2] % 16) * 23.7f) + _D, ((REG[2] / 16) * 16.3f) + _D, _A, _L); //C
            if (D) g.FillRectangle(new SolidBrush(colores.RAM_D), ((REG[3] % 16) * 23.7f) + _D, ((REG[3] / 16) * 16.3f) + _D, _A, _L); //D

            string ans = "";
            for (int i = 0; i < 256; i++)
            {
                ans = Convert.ToString(RAM[i] % 256, b).PadLeft(2, '0').ToUpper();
                g.DrawString(ans, new Font("Consolas", (b == 10) ? 8 : 10.5f), new SolidBrush(colores.text_regular), (((i % 16) * 23.7f) + 3) + _D, (((i / 16) * 16.3f)) + _D);


                if ((i + 1) % 16 == 0) ans += (char)10;
            }
            g = register;
            /////////////////////////////////Graficar REGISTROS
            g.Clear(colores.objects);

            int n = 10;
            _A = 24; _L = 17;

            if (A) g.FillRectangle(new SolidBrush(colores.RAM_A), 0 + n, 20, _A, _L); //A
            if (B) g.FillRectangle(new SolidBrush(colores.RAM_B), 30 + n, 20, _A, _L); //B
            if (C) g.FillRectangle(new SolidBrush(colores.RAM_C), 60 + n, 20, _A, _L); //C
            if (D) g.FillRectangle(new SolidBrush(colores.RAM_D), 90 + n, 20, _A, _L); //D
            g.FillRectangle(new SolidBrush(colores.RAM_IP), 120 + n, 20, _A, _L); //IP
            g.FillRectangle(new SolidBrush(colores.RAM_SP), 150 + n, 20, _A, _L); //SP

            g.DrawString("A", new Font("Consolas", 10), new SolidBrush(colores.text_regular), 0 + n, 5);
            g.DrawString(Convert.ToString(REG[0], b).ToUpper(), new Font("Consolas", 10), new SolidBrush(colores.text_regular), 0 + n, 20);

            g.DrawString("B", new Font("Consolas", 10), new SolidBrush(colores.text_regular), 30 + n, 5);
            g.DrawString(Convert.ToString(REG[1], b).ToUpper(), new Font("Consolas", 10), new SolidBrush(colores.text_regular), 30 + n, 20);

            g.DrawString("C", new Font("Consolas", 10), new SolidBrush(colores.text_regular), 60 + n, 5);
            g.DrawString(Convert.ToString(REG[2], b).ToUpper(), new Font("Consolas", 10), new SolidBrush(colores.text_regular), 60 + n, 20);

            g.DrawString("D", new Font("Consolas", 10), new SolidBrush(colores.text_regular), 90 + n, 5);
            g.DrawString(Convert.ToString(REG[3], b).ToUpper(), new Font("Consolas", 10), new SolidBrush(colores.text_regular), 90 + n, 20);

            g.DrawString("IP", new Font("Consolas", 10), new SolidBrush(colores.text_regular), 120 + n, 5);
            g.DrawString(Convert.ToString(REG[5], b).ToUpper(), new Font("Consolas", 10), new SolidBrush(colores.text_regular), 120 + n, 20);

            g.DrawString("SP", new Font("Consolas", 10), new SolidBrush(colores.text_regular), 150 + n, 5);
            g.DrawString(Convert.ToString(REG[4], b).ToUpper(), new Font("Consolas", 10), new SolidBrush(colores.text_regular), 150 + n, 20);

            g.DrawString("Zero", new Font("Consolas", 10), new SolidBrush(colores.text_regular), 180 + n, 5);
            g.DrawString(Convert.ToString(zero), new Font("Consolas", 10), new SolidBrush(colores.text_regular), 180 + n, 20);

            g.DrawString("Carry", new Font("Consolas", 10), new SolidBrush(colores.text_regular), 230 + n, 5);
            g.DrawString(Convert.ToString(carry), new Font("Consolas", 10), new SolidBrush(colores.text_regular), 230 + n, 20);

            g.DrawString("Input", new Font("Consolas", 10), new SolidBrush(colores.text_regular), 280 + n, 5);
            g.DrawString(Convert.ToString(input), new Font("Consolas", 10), new SolidBrush(colores.text_regular), 280 + n, 20);

            g.DrawString("Fault", new Font("Consolas", 10), new SolidBrush(colores.text_regular), 330 + n, 5);
            g.DrawString(Convert.ToString(fault), new Font("Consolas", 10), new SolidBrush(colores.text_regular), 330 + n, 20);

            g = salida;
            ///////////////////////////Graficar OUTPUT
            g.Clear(Color.FromArgb(37, 37, 38));
            for (int i = 232; i <= 255; i++)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(63, 63, 70)), (i - 232 )* 16 + 3, 5, 15, 30);
                g.DrawString(((char)RAM[i]).ToString(), new Font("Consolas", 17), new SolidBrush(colores.text_regular), (i-232) * 16 + 0, 7);
            }
        }
    }
    public static class UnidadAritmeticaLogica
    {
        public static void MOV(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a = b;
        }
        public static void XCH(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            byte t = a;
            a = b;
            b = t;
        }

        public static void ADD(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            carry = (a + b) > 255;
            a = (byte)((a + b) % 256);
        }
        public static void SUB(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            carry = (a - b) < 0;
            a = (byte)((a - b) % 256);
        }
        public static void MUL(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            carry = (a * b) > 255;
            a = (byte)((a * b) % 256);
        }
        public static void DIV(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            fault = b == 0;
            if (b != 0)
                a = (byte)(a / b);
        }
        public static void MOD(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            fault = b == 0;
            if (b != 0)
                a = (byte)(a % b);
        }
        
        public static void AND(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a = (byte)(a & b);
        }
        public static void OR(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a = (byte)(a | b);
        }
        public static void XOR(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a = (byte)(a ^ b);
        }
        public static void SHL(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a = (byte)(a << b);
        }
        public static void SHR(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a = (byte)(a >> b);
        }

        public static void OBIT(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            fault = b > 8;
            carry = zero;
            zero = ((a >> (b - 1)) & 1) == 1;
        }
        public static void IBIT(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            if (zero == true)
            {
                fault = b > 8;
                a = (byte)(a | (1 << (b - 1)));
            }
            else
            {
                fault = b > 8;
                a = (byte)(a & ~(1 << (b - 1)));
            }
        }

        public static void SETZ(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            zero = b != 0;
        }
        public static void SETC(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            carry = b != 0;
        }
        public static void SETI(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            fault = b != 0;
        }

        public static void CMP(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            carry = zero;
            zero = a == b;
        }
        public static void MAJ(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            carry = zero;
            zero = a > b;
        }
        public static void MIN(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            carry = zero;
            zero = a < b;
        }
        public static void INC(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a++;
        }
        public static void DEC(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a--;
        }
        public static void SQRT(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a = (byte)Math.Sqrt(a);
        }
        public static void NOT(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a = (byte)(~a);
        }
        public static void NEG(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a = (byte)(~a + 1);
        }

        public static void PUSH(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            a = b;
        }
        public static void POP(ref byte a, ref byte b, ref bool zero, ref bool carry, ref bool fault)
        {
            b = a;
        }
    }
    public class Compilador
    {
        Listas listas;
        ValidacionSintactica vSintactica = new ValidacionSintactica();
        public Compilador(Listas listas)
        {
            this.listas = listas;
            
        }
        public Bitmap CompilarTexto(string texto)
        {
            listas.Reset();
            listas.lineas = ManejoTexto.ObtenerLineas(texto);
            List<string> palabras = ManejoTexto.ObtenerPalabras(texto);
            List<int> lineasReclamadas = new List<int>();

            byte ID = 0;
            byte[] RAM = new byte[256];
            Bitmap ans = new Bitmap(16, 16);

            for (int i = 0; i < palabras.Count; i++)
            {
                if (palabras[i][palabras[i].Length - 1] == ':')
                {
                    string n = palabras[i].Substring(0, palabras[i].Length - 1).ToUpper();
                    if (!vSintactica.InstruccionValida(n))
                    {
                        listas.labels.Add(palabras[i].Substring(0, palabras[i].Length - 1), ID);
                        continue;
                    }

                }

                for (int e = 0; e < listas.lineas.Count; e++)
                {
                    string sub = "";
                    if (!lineasReclamadas.Exists(x => x == e))
                    {
                        sub = texto.Substring(listas.lineas[e].Key, listas.lineas[e].Value);
                        if (sub.Contains(palabras[i]))
                        {
                            listas.Dlineas.Add(ID, listas.lineas[e]);
                            lineasReclamadas.Add(e);
                            break;
                        }
                    }
                }


                int cantTerms = vSintactica.CantidadTerminos(palabras[i]);
                if (cantTerms == 2)
                {
                    RAM[ID + 0] = (byte)(Operacion(palabras[i]) + Terminos(palabras[i + 1], palabras[i + 2], ID));
                    RAM[ID + 1] = TerminoAValor(palabras[i + 1], (byte)(ID + 1));
                    RAM[ID + 2] = TerminoAValor(palabras[i + 2], (byte)(ID + 2));

                    listas.pos_instrucciones.Add(ID);
                    ID += 3;
                    i += 2;
                }
                else if (cantTerms == 1)
                {
                    if (palabras[i].ToUpper() != "DB")
                    {
                        int n = Terminos(palabras[i + 1], ID);
                        RAM[ID + 0] = (byte)(Operacion(palabras[i + 0]) + n);
                        RAM[ID + 1] = TerminoAValor(palabras[i + 1], (byte)(ID + 1));

                        if (RAM[ID] >= 239 + n && RAM[ID] <= 253 + n)
                            RAM[ID] -= (byte)n;

                        else if (palabras[i].ToUpper() == "CALL") RAM[ID] = 254;

                        listas.pos_instrucciones.Add(ID);
                        i += 1;
                        ID += 2;
                    }
                    else  //BD
                    {
                        byte num;
                        if (vSintactica.EsNumero(palabras[i + 1], out num))
                            RAM[ID++] = num;
                        else
                        {
                            if (palabras[i + 1].Length >= 3)
                            {
                                if (palabras[i + 1][0] == '\'' && palabras[i + 1][palabras[i + 1].Length - 1] == '\'')
                                {
                                    if (palabras[i + 1].Length == 3)
                                    {
                                        RAM[ID++] = (byte)palabras[i + 1][1];
                                    }
                                }
                                else if (palabras[i + 1][0] == '\"' && palabras[i + 1][palabras[i + 1].Length - 1] == '\"')
                                {
                                    string s = palabras[i + 1].Substring(1, palabras[i + 1].Length - 2);
                                    foreach (char c in s)
                                        RAM[ID++] = (byte)c;
                                    RAM[ID++] = 0;
                                }
                            }
                        }
                        i += 1;
                    }
                }
                else if (cantTerms == 0)
                {
                    RAM[ID] = Operacion(palabras[i]);
                    listas.pos_instrucciones.Add(ID);

                    ID += 1;
                }
            }

            foreach (KeyValuePair<string, byte> k in listas.tempLabel)
                if (listas.labels.ContainsKey(k.Key))
                    RAM[k.Value] = listas.labels[k.Key];
            
            for (int i = 0; i < 256; i++)
                ans.SetPixel(i % 16, i / 16, Color.FromArgb(RAM[i], RAM[i], RAM[i]));

            //txt.Select(0, 0);

            return ans;
        }
        public string ComprobarSintaxis(string texto)
        {
            listas.Reset();
            List<string> palabras = ManejoTexto.ObtenerPalabras(texto);
            listas.lineas = ManejoTexto.ObtenerLineas(texto);
            List<int> lineasReclamadas = new List<int>();
            bool check1 = false, check2 = false;

            for (int i = 0; i < palabras.Count; i++)
            {
                check1 = false; check2 = false;
                if (palabras[i][palabras[i].Length - 1] == ':')
                {
                    string n = palabras[i].Substring(0, palabras[i].Length - 1).ToUpper();
                    if (!vSintactica.InstruccionValida(n))
                    {
                        listas.LabelSintx.Add(palabras[i].Substring(0, palabras[i].Length - 1));
                        check1 = true;
                        continue;
                    }
                    else
                        return "No se puede usar " + n + " como etiqueta";
                }
                for (int e = 0; e < listas.lineas.Count; e++)
                {
                    string sub = "";
                    if (!lineasReclamadas.Exists(x => x == e))
                    {
                        sub = texto.Substring(listas.lineas[e].Key, listas.lineas[e].Value);
                        if (sub.Contains(palabras[i]))
                        {
                            lineasReclamadas.Add(e);
                            break;
                        }
                    }
                }

                int cantTerms = vSintactica.CantidadTerminos(palabras[i]);
                if (cantTerms == 2)
                {
                    if (vSintactica.EsTermino(palabras[i + 1], 1) == 0)
                        return palabras[i] + " no soporta este termino como primer operando";
                    if (vSintactica.EsTermino(palabras[i + 1], 1) == 2)
                        listas.AgregarTerminoTemmpLabelSintx(palabras[i + 1]);

                    if (vSintactica.EsTermino(palabras[i + 2], 2) == 0)
                        return palabras[i] + " no soporta este termino como segundo operando";
                    if (vSintactica.EsTermino(palabras[i + 2], 2) == 2)
                        listas.AgregarTerminoTemmpLabelSintx(palabras[i + 2]);

                    i += 2;
                    check2 = true;
                }
                else if (cantTerms == 1)
                {
                    if (palabras[i].ToUpper() != "DB")
                    {
                        string n = palabras[i + 1];
                        string up = palabras[i].ToUpper();
                        if (vSintactica.EsTermino(palabras[i + 1], 1) == 0 &&  (up != "PUSH"&& up != "SETZ" && up != "SETC" && up != "SETI"))
                            return palabras[i] + " no soporta este termino como primer operando";
                        if (vSintactica.EsTermino(palabras[i + 1], 1) == 2)
                            listas.AgregarTerminoTemmpLabelSintx(palabras[i + 1]);

                        i += 1;
                        check2 = true;
                    }
                    else  //BD
                    {
                        byte num;
                        if (!vSintactica.EsNumero(palabras[i + 1], out num) && palabras[i + 1][0] != '"' && palabras[i + 1][0] != '\'')
                            return palabras[i] + " no soporta este termino como primer operando";

                        i += 1;
                        check2 = true;
                    }
                }
                else if (cantTerms == 0)
                {
                    check2 = true;
                }
                if (check1 == false && check2 == false)
                    return "Error de sintaxis |" + palabras[i] + "| no valido";
            }

            foreach (string k in listas.tempLabelSintx)
                if (listas.LabelSintx.Exists(x => x == k))
                    continue;
                else
                { return "Etiqueta no encontrada:  " + k; }



            return "OK";
        }

        #region Compilación
        public byte TerminoAValor(string text, byte ID)
        {
            string original = text;

            if (listas.labels.ContainsKey(text))
                return listas.labels[text];

            text = text.ToUpper();

            byte num = 0;
            if (vSintactica.EsNumero(original, out num))
                return num;

            if (text == "A" || text == "[A]") return 0;
            if (text == "B" || text == "[B]") return 1;
            if (text == "C" || text == "[C]") return 2;
            if (text == "D" || text == "[D]") return 3;
            if (text == "SP" || text == "[SP]") return 4;
            if (text == "IP" || text == "[IP]") return 5;

            if (text.Length >= 3)
            {
                if (vSintactica.EsNumero(text.Substring(1, text.Length - 2), out num))
                    return num;
                if (listas.labels.ContainsKey(original.Substring(1, original.Length - 2)))
                    return listas.labels[original.Substring(1, original.Length - 2)];

                if (original[0] == '[')
                {
                    listas.tempLabel.Add(new KeyValuePair<string, byte>(original.Substring(1, original.Length - 2), ID));
                    return 255;
                }
            }

            listas.tempLabel.Add(new KeyValuePair<string, byte>(original, ID));

            return 255;
        }
        public byte Operacion(string inst)
        {
            return vSintactica.GetNInstruccion(inst);
        }
        public byte Terminos(string uno, string dos, byte ID)
        {
            bool reg1 = false, add1 = false, adr1 = false;
            bool reg2 = false, add2 = false, adr2 = false, con2 = false;

            string original1 = uno;
            string original2 = dos;

            if (listas.labels.ContainsKey(dos))
                con2 = true;

            uno = uno.ToUpper();
            dos = dos.ToUpper();

            byte num;
            if (uno == "A" || uno == "B" || uno == "C" || uno == "D" || uno == "SP" || uno == "IP")
                reg1 = true;
            else if (uno == "[A]" || uno == "[B]" || uno == "[C]" || uno == "[D]" || uno == "[SP]" || uno == "[IP]")
                adr1 = true;
            else if (uno.Length >= 3)
            {
                if (uno[0] == '[' && uno[uno.Length - 1] == ']')
                {
                    if (vSintactica.EsNumero(uno.Substring(1, uno.Length - 2), out num))
                        add1 = true;
                    else if (listas.labels.ContainsKey(original1.Substring(1, original1.Length - 2)))
                        add1 = true;
                }
            }


            if (dos == "A" || dos == "B" || dos == "C" || dos == "D" || dos == "SP" || dos == "IP")
                reg2 = true;
            else if (dos == "[A]" || dos == "[B]" || dos == "[C]" || dos == "[D]" || dos == "[SP]" || dos == "[IP]")
                adr2 = true;
            else if (vSintactica.EsNumero(original2, out num))
                con2 = true;
            else if (dos.Length >= 3)
            {
                if (dos[0] == '[' && dos[dos.Length - 1] == ']')
                {
                    if (vSintactica.EsNumero(original2.Substring(1, original2.Length - 2), out num))
                        add2 = true;
                    else if (listas.labels.ContainsKey(original2.Substring(1, original2.Length - 2)))
                        add2 = true;
                }
            }
            if (!(reg1 || add1 || adr1))
            {
                if (original1.Length >= 3)
                {
                    if (original1[0] == '[' && original1[original1.Length - 1] == ']')
                    {
                        listas.tempLabel.Add(new KeyValuePair<string, byte>(original1.Substring(1, original1.Length - 2), (byte)(ID + 1)));
                        add1 = true;
                    }
                }
            }
            if (!(reg2 || add2 || adr2 || con2))
            {
                if (original2.Length >= 3)
                {
                    if (original2[0] == '[' && original2[original2.Length - 1] == ']')
                    {
                        listas.tempLabel.Add(new KeyValuePair<string, byte>(original2.Substring(1, original2.Length - 2), (byte)(ID + 2)));
                        add2 = true;
                    }
                }
            }

            if (reg1 && reg2) return 0;
            if (reg1 && add2) return 1;
            if (reg1 && adr2) return 2;
            if (reg1 && con2) return 3;

            if (add1 && reg2) return 4;
            if (add1 && add2) return 5;
            if (add1 && adr2) return 6;
            if (add1 && con2) return 7;

            if (adr1 && reg2) return 8;
            if (adr1 && add2) return 9;
            if (adr1 && adr2) return 10;
            if (adr1 && con2) return 11;


            return 0;
        }
        public byte Terminos(string uno, byte ID)
        {
            byte num;
            bool reg1 = false, add1 = false, adr1 = false, con1 = false;

            if (listas.labels.ContainsKey(uno))
                con1 = true;
            string original = uno;
            uno = uno.ToUpper();


            if (uno == "A" || uno == "B" || uno == "C" || uno == "D" || uno == "SP" || uno == "IP")
                reg1 = true;
            else if (uno == "[A]" || uno == "[B]" || uno == "[C]" || uno == "[D]" || uno == "[SP]" || uno == "[IP]")
                adr1 = true;
            else if (uno.Length >= 3 && !vSintactica.EsNumero(original, out num))
            {
                if (uno[0] == '[' && uno[uno.Length - 1] == ']')
                {
                    if (vSintactica.EsNumero(original.Substring(1, original.Length - 2), out num))
                        add1 = true;
                    else if (listas.labels.ContainsKey(original.Substring(0, original.Length - 2)))
                        adr1 = true;
                }
            }
            else if (vSintactica.EsNumero(original, out num))
                con1 = true;

            if (!(reg1 || add1 || adr1))
            {
                if (original.Length >= 3)
                {
                    if (original[0] == '[' && original[original.Length - 1] == ']')
                    {
                        listas.tempLabel.Add(new KeyValuePair<string, byte>(original.Substring(1, original.Length - 2), (byte)(ID + 1)));
                        add1 = true;
                    }
                }
            }

            if (reg1) return 0;
            if (add1) return 1;
            if (adr1) return 2;
            if (con1) return 3;


            return 1;

        }
        #endregion
    }

}