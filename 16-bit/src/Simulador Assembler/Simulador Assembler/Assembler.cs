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
    public static class ManejoTexto
    {
        public static List<string> ObtenerPalabras(string texto)
        {
            List<string> palabras = new List<string>();
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
    }
    public class Instruccion
    {
        public string nombre { get; set; }
        public ushort terminos { get; set; }
        public ushort value { get; set; }
        public Instruccion(string nombre, ushort terminos, ushort value)
        {
            this.nombre = nombre;
            this.terminos = terminos;
            this.value = value;
        }
    }
    public class Sintaxis
    {
        public string istructionSet { get; set; }

        public List<Instruccion> instrucciones { get; set; }

        public Sintaxis()
        {
            instrucciones = new List<Instruccion>();

            instrucciones.Add(new Instruccion("HLT", 0, 0));
            instrucciones.Add(new Instruccion("DB", 1, 1));

            instrucciones.Add(new Instruccion("MOV", 2, 2));
            instrucciones.Add(new Instruccion("XCH", 2, 3));

            instrucciones.Add(new Instruccion("ADD",  2, 4));
            instrucciones.Add(new Instruccion("SUB",  2, 5));
            instrucciones.Add(new Instruccion("MUL",  2, 6));
            instrucciones.Add(new Instruccion("DIV",  2, 7));
            instrucciones.Add(new Instruccion("IMUL", 2, 8));
            instrucciones.Add(new Instruccion("IDIV", 2, 9));
            instrucciones.Add(new Instruccion("MOD",  2, 10));
            instrucciones.Add(new Instruccion("INC",  1, 11));
            instrucciones.Add(new Instruccion("DEC",  1, 12));
            instrucciones.Add(new Instruccion("INV",  1, 13));

            instrucciones.Add(new Instruccion("AND", 2, 14));
            instrucciones.Add(new Instruccion("OR", 2, 15));
            instrucciones.Add(new Instruccion("NOT", 1, 16));
            instrucciones.Add(new Instruccion("XOR", 2, 17));

            instrucciones.Add(new Instruccion("SHL", 2, 18));
            instrucciones.Add(new Instruccion("SHR", 2, 19));
            instrucciones.Add(new Instruccion("REV", 1, 20));
            instrucciones.Add(new Instruccion("BIT",  2, 21));
            instrucciones.Add(new Instruccion("BITR", 2, 22));
            instrucciones.Add(new Instruccion("BITS", 2, 23));
            instrucciones.Add(new Instruccion("BITC", 2, 24));

            instrucciones.Add(new Instruccion("CMP", 2, 25));
            instrucciones.Add(new Instruccion("MAJ", 2, 26));
            instrucciones.Add(new Instruccion("MIN", 2, 27));

            instrucciones.Add(new Instruccion("FZR", 0, 28));
            instrucciones.Add(new Instruccion("FZS", 0, 29));
            instrucciones.Add(new Instruccion("FZC", 0, 30));

            instrucciones.Add(new Instruccion("FCR", 0, 31));
            instrucciones.Add(new Instruccion("FCS", 0, 32));
            instrucciones.Add(new Instruccion("FCC", 0, 33));

            instrucciones.Add(new Instruccion("FIR", 0, 34));
            instrucciones.Add(new Instruccion("FIS", 0, 35));
            instrucciones.Add(new Instruccion("FIC", 0, 36));

            instrucciones.Add(new Instruccion("PUSH", 1, 37));
            instrucciones.Add(new Instruccion("POP", 1, 38));

            instrucciones.Add(new Instruccion("PUSHF", 0, 39));
            instrucciones.Add(new Instruccion("POPF", 0, 40));

            instrucciones.Add(new Instruccion("PUSHR", 0, 41));
            instrucciones.Add(new Instruccion("POPR", 0, 42));

            instrucciones.Add(new Instruccion("JMP", 1, 43));

            instrucciones.Add(new Instruccion("JC", 1, 44));
            instrucciones.Add(new Instruccion("JNC", 1, 45));
            instrucciones.Add(new Instruccion("JZ", 1, 46));
            instrucciones.Add(new Instruccion("JNZ", 1, 47));
            instrucciones.Add(new Instruccion("JI", 1, 48));
            instrucciones.Add(new Instruccion("JNI", 1, 49));

            instrucciones.Add(new Instruccion("JAT", 1, 50));
            instrucciones.Add(new Instruccion("JATF", 1, 51));
            instrucciones.Add(new Instruccion("JAFT", 1, 52));
            instrucciones.Add(new Instruccion("JAF", 1, 53));

            instrucciones.Add(new Instruccion("JOT", 1, 54));
            instrucciones.Add(new Instruccion("JOTF", 1, 55));
            instrucciones.Add(new Instruccion("JOFT", 1, 56));
            instrucciones.Add(new Instruccion("JOF", 1, 57));

            instrucciones.Add(new Instruccion("CALL", 1, 58));
            instrucciones.Add(new Instruccion("RET", 0, 59));
        
            instrucciones.Add(new Instruccion("CREG", 0, 60));
            instrucciones.Add(new Instruccion("CFLG", 0, 61));

            foreach (Instruccion i in instrucciones)
                istructionSet += i.nombre + '|';

            istructionSet += '\b';
        }

        #region Comprobaciones
        public Instruccion GetInstruccion(string inst)
        {
            return instrucciones.Find(x => x.nombre == inst.ToUpper());
        }
        public Instruccion GetInstruccion(ushort inst)
        {
            return instrucciones.Find(x => x.value == inst);
        }
        public bool InstruccionValida(string inst)
        {
            return instrucciones.Exists(x => x.nombre == inst.ToUpper());
        }
        public ushort EsTermino(string text, ushort n)
        {
            ushort a;
            if (EsNumero(text, out a) && n == 2)
                return 1;

            if (EsNumero(text, out a) && n == 1)
                return 0;

            if ((text.ToUpper() == "TRUE" || text.ToUpper() == "FALSE") && n == 2)
                return 1;
            if ((text.ToUpper() == "TRUE" || text.ToUpper() == "FALSE") && n == 1)
                return 0;


            if (text == "A" || text == "[A]") return 1;
            if (text == "B" || text == "[B]") return 1;
            if (text == "C" || text == "[C]") return 1;
            if (text == "D" || text == "[D]") return 1;
            if (text == "E" || text == "[E]") return 1;
            if (text == "F" || text == "[F]") return 1;
            if (text == "G" || text == "[G]") return 1;
            if (text == "H" || text == "[H]") return 1;
            if (text == "SP" || text == "[SP]") return 1;
            if (text == "IP" || text == "[IP]") return 1;

            if (text.Length >= 3)
            {
                if (text[0] == '[' && text[text.Length - 1] == ']')
                {
                    if (EsNumero(text.Substring(1, text.Length - 2), out a))
                        return 1;
                }
                if (text[0] == '(' && text[text.Length - 1] == ')')
                {
                    if (EsNumero(text.Substring(1, text.Length - 2), out a))
                        return 1;
                }
                if (text[0] == '{' && text[text.Length - 1] == '}')
                {
                    if (EsNumero(text.Substring(1, text.Length - 2), out a))
                        return 1;
                }
                return 2;
            }
            return 0;
        }
        public bool EsNumero(string text, out ushort s)
        {
            ushort a = 0;
            if (ushort.TryParse(text, out a))
            { s = a; return true; }

            text = text.ToUpper();
            if (text == "TRUE")
            { s = 1; return true; }
            if (text == "FALSE")
            { s = 0; return true; }

            if (text.Length >= 3)
            {
                if (text[0] == '0' && text[1] == 'X')
                { s = (ushort)(Convert.ToInt32(text.Substring(2), 16)); return true; }

                int cantLetras = 0;
                foreach (char c in text)
                    if (char.IsLetter(c))
                        cantLetras++;

                if (cantLetras <= 1)
                {
                    if (text[0] == '0' && text[1] == 'B')
                    { s = (ushort)(Convert.ToInt32(text.Substring(2), 2)); return true; }
                    if (text[0] == '0' && text[1] == 'O')
                    { s = (ushort)(Convert.ToInt32(text.Substring(2), 8)); return true; }
                }
            }

            s = 0; return false;
        }
        #endregion
    }
    public class OrdenadorRD1601
    {
        delegate void Funcion(ref ushort a, ref ushort b);
        #region UnidadAritmeticaLogica

        void MOV(ref ushort a, ref ushort b)
        {
            a = b;
        }
        void XCH(ref ushort a, ref ushort b)
        {
            ushort temp = a;
            a = b;
            b = temp;
        }

        void ADD(ref ushort a, ref ushort b)
        {
            if (a + b > 0xFFFF)
                FLG[1] = true;

            a = (ushort)(a + b);
        }
        void SUB(ref ushort a, ref ushort b)
        {
            if (a - b < 0)
            {
                FLG[1] = true;
                a = (ushort)(a - b);
            }
            else
                a = (ushort)(a - b);
        }
        void MUL(ref ushort a, ref ushort b)
        {
            if (a * b > 0xFFFF)
                FLG[1] = true;

            a = (ushort)(a * b);
        }
        void DIV(ref ushort a, ref ushort b)
        {
            if (b == 0)
                throw new Exception("Aritmetic error: Divide by 0 is illegal");
            else
                a = (ushort)(a / b);
        }
        void MOD(ref ushort a, ref ushort b)
        {
            if (b == 0)
                throw new Exception("Aritmetic error: Divide by 0 is illegal");
            else
                a = (ushort)(a % b);
        }
        void IMUL(ref ushort a, ref ushort b)
        {
            if (a * b > 0xFFFF)
                FLG[1] = true;

            a = (ushort)((short)a * (short)b);
        }
        void IDIV(ref ushort a, ref ushort b)
        {
            if (b == 0)
                throw new Exception("Aritmetic error: Divide by 0 is illegal");
            else
                a = (ushort)((short)a / (short)b);
        }
        void INC(ref ushort a, ref ushort b)
        {
            if (a + 1 > 0xFFFF)
                FLG[1] = true;

            a++;
        }
        void DEC(ref ushort a, ref ushort b)
        {
            if (a - 1 < 0)
                FLG[1] = true;

            a--;
        }
        void INV(ref ushort a, ref ushort b)
        {
            a = (ushort)(~a + 1);
        }

        void AND(ref ushort a, ref ushort b)
        {
            a = (ushort)(a & b);
        }
        void OR(ref ushort a, ref ushort b)
        {
            a = (ushort)(a | b);
        }
        void XOR(ref ushort a, ref ushort b)
        {
            a = (ushort)(a ^ b);
        }
        void NOT(ref ushort a, ref ushort b)
        {
            a = (ushort)(~a);
        }

        void SHL(ref ushort a, ref ushort b)
        {
            a = (ushort)(a << b);
        }
        void SHR(ref ushort a, ref ushort b)
        {
            a = (ushort)(a >> b);
        }
        void REV(ref ushort a, ref ushort b)
        {
            string BIT = Convert.ToString(a, 2).PadLeft(16, '0');
            string ANS = ""; int n = 15;
            while (n >= 0)
                ANS += BIT[n--];
            a = (ushort)(Convert.ToUInt16(ANS, 2));
        }
        void BIT(ref ushort a, ref ushort b)
        {
            FLG[3] = b > 16 || b == 0;
            FLG[1] = FLG[0];
            FLG[0] = ((a >> (b - 1)) & 1) == 1;
        }
        void BITR(ref ushort a, ref ushort b)
        {
            FLG[3] = b > 16 || b == 0;
            a = (ushort)(a & ~(1 << (b - 1)));
        }
        void BITS(ref ushort a, ref ushort b)
        {
            FLG[3] = b > 16 || b == 0;
            a = (ushort)(a | (1 << (b - 1)));
        }
        void BITC(ref ushort a, ref ushort b)
        {
            FLG[3] = b > 16 || b == 0;

            if (((a >> (b - 1)) & 1) == 1)
                a = (ushort)(a & ~(1 << (b - 1)));
            else
                a = (ushort)(a | (1 << (b - 1)));
        }
        
        void CMP(ref ushort a, ref ushort b)
        {
            FLG[1] = FLG[0];
            FLG[0] = a == b;
        }
        void MAJ(ref ushort a, ref ushort b)
        {
            FLG[1] = FLG[0];
            FLG[0] = a > b;
        }
        void MIN(ref ushort a, ref ushort b)
        {
            FLG[1] = FLG[0];
            FLG[0] = a < b;
        }

        void FZR(ref ushort a, ref ushort b)
        {
            FLG[0] = false;
        }
        void FZS(ref ushort a, ref ushort b)
        {
            FLG[0] = true;
        }
        void FZC(ref ushort a, ref ushort b)
        {
            FLG[0] = !FLG[0];
        }

        void FCR(ref ushort a, ref ushort b)
        {
            FLG[1] = false;
        }
        void FCS(ref ushort a, ref ushort b)
        {
            FLG[1] = true;
        }
        void FCC(ref ushort a, ref ushort b)
        {
            FLG[1] = !FLG[1];
        }

        void FIR(ref ushort a, ref ushort b)
        {
            FLG[2] = false;
        }
        void FIS(ref ushort a, ref ushort b)
        {
            FLG[2] = true;
        }
        void FIC(ref ushort a, ref ushort b)
        {
            FLG[2] = !FLG[2];
        }

        void PUSH(ref ushort a, ref ushort b)
        {
            RAM[REG[8]--] = a;
        }
        void POP(ref ushort a, ref ushort b)
        {
            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }

            a = RAM[++REG[8]];
        }

        void PUSHF(ref ushort a, ref ushort b)
        {
            RAM[REG[8]--] = (ushort)((FLG[0])? 1 : 0);
            RAM[REG[8]--] = (ushort)((FLG[1]) ? 1 : 0);
            RAM[REG[8]--] = (ushort)((FLG[2]) ? 1 : 0);
        }
        void POPF(ref ushort a, ref ushort b)
        {
            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }

            FLG[2] = RAM[++REG[8]] == 1;

            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }

            FLG[1] = RAM[++REG[8]] == 1;

            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }

            FLG[0] = RAM[++REG[8]] == 1;
        }

        void PUSHR(ref ushort a, ref ushort b)
        {
            RAM[REG[8]--] = REG[0];
            RAM[REG[8]--] = REG[1];
            RAM[REG[8]--] = REG[2];
            RAM[REG[8]--] = REG[3];
            RAM[REG[8]--] = REG[4];
            RAM[REG[8]--] = REG[5];
            RAM[REG[8]--] = REG[6];
            RAM[REG[8]--] = REG[7];
        }
        void POPR(ref ushort a, ref ushort b)
        {
            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }

            REG[7] = RAM[++REG[8]];

            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }
            REG[6] = RAM[++REG[8]];

            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }
            REG[5] = RAM[++REG[8]];

            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }
            REG[4] = RAM[++REG[8]];

            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }
            REG[3] = RAM[++REG[8]];

            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }
            REG[2] = RAM[++REG[8]];

            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }
            REG[1] = RAM[++REG[8]];

            if (REG[8] + 1 > limit_SP)
            { throw new Exception("UnderFlow: Stack Pointer (SP) has exceed its limit"); }
            REG[0] = RAM[++REG[8]];
        }

        void CFLG(ref ushort a, ref ushort b)
        {
            FLG[2] = false;
            FLG[1] = false;
            FLG[0] = false;
        }
        void CREG(ref ushort a, ref ushort b)
        {
            REG[7] = 0;
            REG[6] = 0;
            REG[5] = 0;
            REG[4] = 0;
            REG[3] = 0;
            REG[2] = 0;
            REG[1] = 0;
            REG[0] = 0;
        }
        #endregion

        Sintaxis vSintactica = new Sintaxis();

        public List<int> pos_instrucciones { get; set; }
        public Dictionary<int, KeyValuePair<int, int>> lineas { get; set; }

        Color paleta;
        ushort[] REG;
        ushort[] RAM;
        bool[] FLG;

        public ushort limit_SP;
        public ushort input_alloc;
        public ushort output_alloc_screen;
        public ushort output_alloc_text;

        /* INFORMATION
         * 
         * FLAGS:
         *      zero  = 0
         *      carry = 1
         *      input = 2
         *      fault = 3
         * REGISTERS:
         *      IP = 9
         *      SP = 8
         */

        public OrdenadorRD1601()
        {
            pos_instrucciones = new List<int>();
            lineas = new Dictionary<int, KeyValuePair<int, int>>();

            limit_SP = (ushort)(0x10000 - 1);
            input_alloc = 0x89;
            output_alloc_screen = 0;// 0x10000 - 0x400;
            output_alloc_text = 232;// 0x10000 - 0x400 - 0x19;

            Reset();
        }
        public void Reset()
        {
            REG = new ushort[0xA];
            RAM = new ushort[0x10000];
            FLG = new bool[0x4];

            
            REG[8] = (ushort)limit_SP;
            REG[9] = 0;



            pos_instrucciones.Clear();
            lineas.Clear();
        }
        public bool EjecutarInstruccion(ref int i, ref int f)
        {
            try
            {
                Funcion op = null;
                ushort inst = (ushort)((RAM[REG[9]] & 0xFF00) >> 8);
                ushort ter1 = (ushort)((RAM[REG[9]] & 0x00F0) >> 4);
                ushort ter2 = (ushort)(RAM[REG[9]] & 0x000F);

                Instruccion instruccion = vSintactica.GetInstruccion(inst);

                if (instruccion == null)
                    throw new Exception("Instruction not found: 0x" + inst);

                string sinst = instruccion.nombre;
                int cantTerms = instruccion.terminos;

                

                switch (sinst)
                {
                    case "MOV": op = this.MOV; break;
                    case "XCH": op = this.XCH; break;

                    case "ADD": op = this.ADD; break;
                    case "SUB": op = this.SUB; break;
                    case "MUL": op = this.MUL; break;
                    case "DIV": op = this.DIV; break;
                    case "IMUL": op = this.IMUL; break;
                    case "IDIV": op = this.IDIV; break;
                    case "MOD": op = this.MOD; break;
                    case "INC": op = this.INC; break;
                    case "DEC": op = this.DEC; break;
                    case "INV": op = this.INV; break;

                    case "AND": op = this.AND; break;
                    case "OR": op = this.OR; break;
                    case "NOT": op = this.NOT; break;
                    case "XOR": op = this.XOR; break;

                    case "SHL": op = this.SHL; break;
                    case "SHR": op = this.SHR; break;
                    case "REV": op = this.REV; break;
                    case "BIT": op = this.BIT; break;
                    case "BITR": op = this.BITR; break;
                    case "BITS": op = this.BITS; break;
                    case "BITC": op = this.BITC; break;
                        
                    case "CMP": op = this.CMP; break;
                    case "MAJ": op = this.MAJ; break;
                    case "MIN": op = this.MIN; break;

                    case "FZR": op = this.FZR; break;
                    case "FZS": op = this.FZS; break;
                    case "FZC": op = this.FZC; break;

                    case "FCR": op = this.FCR; break;
                    case "FCS": op = this.FCS; break;
                    case "FCC": op = this.FCC; break;
                    
                    case "FIR": op = this.FIR; break;
                    case "FIS": op = this.FIS; break;
                    case "FIC": op = this.FIC; break;

                    case "PUSH": op = this.PUSH; break;
                    case "POP": op = this.POP; break;

                    case "PUSHF": op = this.PUSHF; break;
                    case "POPF": op = this.POPF; break;

                    case "PUSHR": op = this.PUSHR; break;
                    case "POPR": op = this.POPR; break;

                    case "CREG": op = this.CREG; break;
                    case "CFLG": op = this.CFLG; break;

                    case "JMP": REG[9] = RAM[REG[9] + 1]; goto End;
                    
                    case "JC": if (FLG[1] == true) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;
                    case "JNC": if (FLG[1] == false) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;

                    case "JZ": if (FLG[0] == true) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;
                    case "JNZ": if (FLG[0] == false) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;

                    case "JI": if (FLG[2] == true) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;
                    case "JNI": if (FLG[2] == false) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;

                    case "JAT": if (FLG[1] == true && FLG[0] == true) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;
                    case "JAF": if (FLG[1] == false && FLG[0] == false) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;
                    case "JATF": if (FLG[0] == true && FLG[1] == false) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;
                    case "JAFT": if (FLG[0] == false && FLG[1] == true) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;

                    case "JOT": if (FLG[1] == true || FLG[0] == true) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;
                    case "JOF": if (FLG[1] == false || FLG[0] == false) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;
                    case "JOTF": if (FLG[0] == true || FLG[1] == false) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;
                    case "JOFT": if (FLG[0] == false || FLG[1] == true) REG[9] = RAM[REG[9] + 1]; else REG[9] += 2; goto End;

                    case "CALL": RAM[REG[8]--] = (ushort)(REG[9] + 2); REG[9] = RAM[REG[9] + 1]; goto End;
                    case "RET": REG[9] = RAM[++REG[8]]; goto End;
                        
                    case "HLT": return false;
                }

                if (op == null)
                    throw new Exception("Instruccion no encontrada: 0x" + inst);

                if (ter1 == 0 && ter2 == 0) op(ref REG[0], ref REG[0]);

                else if (ter1 == 1 && ter2 == 0) op(ref REG[RAM[REG[9] + 1]], ref REG[0]);
                else if (ter1 == 1 && ter2 == 1) op(ref REG[RAM[REG[9] + 1]], ref REG[RAM[REG[9] + 2]]);
                else if (ter1 == 1 && ter2 == 2) op(ref REG[RAM[REG[9] + 1]], ref RAM[RAM[REG[9] + 2]]);
                else if (ter1 == 1 && ter2 == 3) op(ref REG[RAM[REG[9] + 1]], ref RAM[REG[RAM[REG[9] + 2]]]);
                else if (ter1 == 1 && ter2 == 4) op(ref REG[RAM[REG[9] + 1]], ref RAM[REG[9] + 2]);

                else if (ter1 == 2 && ter2 == 0) op(ref RAM[RAM[REG[9] + 1]], ref REG[0]);
                else if (ter1 == 2 && ter2 == 1) op(ref RAM[RAM[REG[9] + 1]], ref REG[RAM[REG[9] + 2]]);
                else if (ter1 == 2 && ter2 == 2) op(ref RAM[RAM[REG[9] + 1]], ref RAM[RAM[REG[9] + 2]]);
                else if (ter1 == 2 && ter2 == 3) op(ref RAM[RAM[REG[9] + 1]], ref RAM[REG[RAM[REG[9] + 2]]]);
                else if (ter1 == 2 && ter2 == 4) op(ref RAM[RAM[REG[9] + 1]], ref RAM[REG[9] + 2]);

                else if (ter1 == 3 && ter2 == 0) op(ref RAM[REG[RAM[REG[9] + 1]]], ref REG[0]);
                else if (ter1 == 3 && ter2 == 1) op(ref RAM[REG[RAM[REG[9] + 1]]], ref REG[RAM[REG[9] + 2]]);
                else if (ter1 == 3 && ter2 == 2) op(ref RAM[REG[RAM[REG[9] + 1]]], ref RAM[RAM[REG[9] + 2]]);
                else if (ter1 == 3 && ter2 == 3) op(ref RAM[REG[RAM[REG[9] + 1]]], ref RAM[REG[RAM[REG[9] + 2]]]);
                else if (ter1 == 3 && ter2 == 4) op(ref RAM[REG[RAM[REG[9] + 1]]], ref RAM[REG[9] + 2]);

                else if (ter1 == 4 && ter2 == 0) op(ref RAM[REG[9] + 1], ref REG[0]);
                else if (ter1 == 4 && ter2 == 1) op(ref RAM[REG[9] + 1], ref REG[RAM[REG[9] + 2]]);
                else if (ter1 == 4 && ter2 == 2) op(ref RAM[REG[9] + 1], ref RAM[RAM[REG[9] + 2]]);
                else if (ter1 == 4 && ter2 == 3) op(ref RAM[REG[9] + 1], ref RAM[REG[RAM[REG[9] + 2]]]);
                else if (ter1 == 4 && ter2 == 4) op(ref RAM[REG[9] + 1], ref RAM[REG[9] + 2]);
                

                REG[9] += (ushort)(cantTerms + 1);


            End:
                if (lineas.ContainsKey(REG[9]))
                {
                    i = lineas[REG[9]].Key;
                    f = lineas[REG[9]].Value;
                }
                if (sinst == "HLT")
                    return false;


                return !FLG[3];
            }
            catch (Exception e) {
                FLG[3] = true;
                return !FLG[3]; }
        }
        public void Parar()
        {
            FLG[3] = true;
        }
        public void Input(ushort value)
        {
            FLG[2] = true;
            RAM[input_alloc] = value;
        }
        public void Display(Graphics g)
        {
            int px = 128;
            int ancho = (int)(g.VisibleClipBounds.Width / px);
            int alto = (int)(g.VisibleClipBounds.Height / px);
            Brush b = Brushes.White;
            g.Clear(Color.Black);
            int x, y;
            for (int i = output_alloc_screen; i - output_alloc_screen < px * px / 16; i++)
            {
                x = ((i- output_alloc_screen) % (px / 16)) * 16 * ancho;

                y = ((i - output_alloc_screen) / (px / 16)) * alto;

                for (int j = 15; j >= 0; j--)
                    if ((RAM[i] & 1 << j) != 0)
                        g.FillEllipse(b, x + (15 - j) * ancho, y, ancho, alto);

            }
        }
        
        public void GraficarRAM(Graphics g, int page, bool output)
        {
            if (g != null)
            {
                int SP = REG[8];
                int IP = REG[9];

                Color RAM_INST = Color.FromArgb(135, 104, 39);
                Color RAM_IP = Color.FromArgb(0, 122, 204);
                Color RAM_SP = Color.FromArgb(238, 162, 54);
                Color RAM_SP_REMAIN = Color.FromArgb(241, 188, 107);

                Color objects = Color.FromArgb(214, 219, 233);
                
                Brush texto = new SolidBrush(Color.Black);
                Font font = new Font("Consolas", 10.5f);
                ///////////////////////////////////Graficar RAM
                float _A = 40.2f, _L = 19.3f;
                int _D = 0;
                int b = 16;
                string ans = "";
                g.Clear(objects);


                //if (A) g.FillRectangle(new SolidBrush(RAM_A), ((REG_A % 16) * _A) + _D, ((REG_A / 16) * _L) + _D, _A, _L); //A
                //if (B) g.FillRectangle(new SolidBrush(RAM_B), ((REG_B % 16) * _A) + _D, ((REG_B / 16) * _L) + _D, _A, _L); //B
                //if (C) g.FillRectangle(new SolidBrush(RAM_C), ((REG_C % 16) * _A) + _D, ((REG_C / 16) * _L) + _D, _A, _L); //C
                //if (D) g.FillRectangle(new SolidBrush(RAM_D), ((REG_D % 16) * _A) + _D, ((REG_D / 16) * _L) + _D, _A, _L); //D
                //if (E) g.FillRectangle(new SolidBrush(RAM_E), ((REG_E % 16) * _A) + _D, ((REG_E / 16) * _L) + _D, _A, _L); //E
                //if (F) g.FillRectangle(new SolidBrush(RAM_F), ((REG_F % 16) * _A) + _D, ((REG_F / 16) * _L) + _D, _A, _L); //F
                //if (G) g.FillRectangle(new SolidBrush(RAM_G), ((REG_G % 16) * _A) + _D, ((REG_G / 16) * _L) + _D, _A, _L); //G
                //if (H) g.FillRectangle(new SolidBrush(RAM_H), ((REG_H % 16) * _A) + _D, ((REG_H / 16) * _L) + _D, _A, _L); //H

                for (int i = SP + 1; i <= limit_SP; i++)
                    if (i >= 0x100 * page && i < 0x100 * (page + 1))
                        g.FillRectangle(new SolidBrush(RAM_SP_REMAIN), ((i % 16) * _A) + _D, (((i / 16) % 16) * _L) + _D, _A, _L); //SP_REMAIN
                
                for (int i = 0x100 * page; i < 0x100 * (page + 1); i++)
                {
                    ans = Convert.ToString(RAM[i], b).PadLeft(4, '0').ToUpper();
                    g.DrawString(ans, font, texto,
                        (((i % 16) * _A) + 2) + _D, ((((i / 16) % 16) * _L)) + _D + 1);
                }
                if (pos_instrucciones != null)
                    foreach (int i in pos_instrucciones)
                        if (i >= 0x100 * page && i < 0x100 * (page + 1))
                        {
                            g.FillRectangle(new SolidBrush(RAM_INST), ((i % 16) * _A) + _D, (((i / 16) % 16) * _L) + _D, _A, _L);
                            ans = Convert.ToString(RAM[i], b).PadLeft(4, '0').ToUpper();
                            g.DrawString(ans, font, Brushes.White, (((i % 16) * _A) + 2) + _D, ((((i / 16) % 16) * _L)) + _D + 1);

                        }

                if (IP >= 0x100 * page && IP < 0x100 * (page + 1))
                {
                    g.FillRectangle(new SolidBrush(RAM_IP), ((IP % 16) * _A) + _D, (((IP / 16) % 16) * _L) + _D, _A, _L); //IP
                    ans = Convert.ToString(RAM[IP], b).PadLeft(4, '0').ToUpper();
                    g.DrawString(ans, font, Brushes.White, (((IP % 16) * _A) + 2) + _D, ((((IP / 16) % 16) * _L)) + _D + 1);
                }
                if (SP >= 0x100 * page && SP < 0x100 * (page + 1))
                {
                    g.FillRectangle(new SolidBrush(RAM_SP), ((SP % 16) * _A) + _D, (((SP / 16) % 16) * _L) + _D, _A, _L); //SP
                    ans = Convert.ToString(RAM[SP], b).PadLeft(4, '0').ToUpper();
                    g.DrawString(ans, font, Brushes.White, (((SP % 16) * _A) + 2) + _D, ((((SP / 16) % 16) * _L)) + _D + 1);
                }
                if (output == true) // texto
                {
                    for (int i = output_alloc_text; i - output_alloc_text < 32; i++)
                        if (i >= 0x100 * page && i < 0x100 * (page + 1))
                        {
                            g.FillRectangle(Brushes.Gray, ((i % 16) * _A) + _D, (((i / 16) % 16) * _L) + _D, _A, _L);

                            ans = Convert.ToString(RAM[i], b).PadLeft(4, '0').ToUpper();
                            g.DrawString(ans, font, Brushes.White, (((i % 16) * _A) + 2) + _D, ((((i / 16) % 16) * _L)) + _D + 1);
                        }
                }
                else
                {
                    for (int i = output_alloc_screen; i - output_alloc_screen < 1024; i++)
                        if (i >= 0x100 * page && i < 0x100 * (page + 1))
                        {
                            g.FillRectangle(Brushes.Gray, ((i % 16) * _A) + _D, (((i / 16) % 16) * _L) + _D, _A, _L);

                            ans = Convert.ToString(RAM[i], b).PadLeft(4, '0').ToUpper();
                            g.DrawString(ans, font, Brushes.White, (((i % 16) * _A) + 2) + _D, ((((i / 16) % 16) * _L)) + _D + 1);
                        }
                }

                //Grilla
                for (int i = 1; i <= 15; i += 1)
                    g.DrawLine(Pens.DarkGray, _A * i + _D, _D, _A * i + _D, _L * 16 + _D);

                for (int i = 1; i <= 15; i += 1)
                    g.DrawLine(Pens.DarkGray, _D, _L * i + _D, _A * 16 + _D, _L * i + _D);

            }
        }
        public void GraficarREG(Graphics g)
        {
            if (g != null)
            {
                int REG_A = REG[0];
                int REG_B = REG[1];
                int REG_C = REG[2];
                int REG_D = REG[3];
                int REG_E = REG[4];
                int REG_F = REG[5];
                int REG_G = REG[6];
                int REG_H = REG[7];

                int SP = REG[8];
                int IP = REG[9];

                Color RAM_A = Color.FromArgb(87, 150, 53);
                Color RAM_B = Color.FromArgb(219, 195, 0);
                Color RAM_C = Color.DarkViolet;
                Color RAM_D = Color.FromArgb(229, 20, 0);
                Color RAM_E = Color.FromArgb(87, 150, 53);
                Color RAM_F = Color.FromArgb(219, 195, 0);
                Color RAM_G = Color.DarkViolet;
                Color RAM_H = Color.FromArgb(229, 20, 0);

                Color objects = Color.FromArgb(214, 219, 233);

                Brush texto = new SolidBrush(Color.Black);
                Font font = new Font("Consolas", 10.5f);

                g.Clear(objects);
                int n = 25;
                float _A = 40.2f, _L = 19.3f;
                int b = 16;
                //if (A) g.FillRectangle(new SolidBrush(RAM_A), 0 + n, 20, _A, _L);  //A
                //if (B) g.FillRectangle(new SolidBrush(RAM_B), 30 + n, 20, _A, _L); //B
                //if (C) g.FillRectangle(new SolidBrush(RAM_C), 60 + n, 20, _A, _L); //C
                //if (D) g.FillRectangle(new SolidBrush(RAM_D), 90 + n, 20, _A, _L); //D
                //if (E) g.FillRectangle(new SolidBrush(RAM_E), 0 + n, 20, _A, _L);  //E
                //if (F) g.FillRectangle(new SolidBrush(RAM_F), 30 + n, 20, _A, _L); //F
                //if (G) g.FillRectangle(new SolidBrush(RAM_G), 60 + n, 20, _A, _L); //G
                //if (H) g.FillRectangle(new SolidBrush(RAM_H), 90 + n, 20, _A, _L); //H

                //g.FillRectangle(new SolidBrush(RAM_IP), 320 + n - 2, 20, _A, _L); //IP
                //g.FillRectangle(new SolidBrush(RAM_SP), 360 + n - 2, 20, _A, _L); //SP

                g.DrawString("A", font, texto, 11 + n, 5);
                g.DrawString(Convert.ToString(REG_A, b).ToUpper().PadLeft(4, '0'), font, texto, 0 + n, 20);

                g.DrawString("B", font, texto, 11 + 40 + n, 5);
                g.DrawString(Convert.ToString(REG_B, b).ToUpper().PadLeft(4, '0'), font, texto, 40 + n, 20);

                g.DrawString("C", font, texto, 11 + 80 + n, 5);
                g.DrawString(Convert.ToString(REG_C, b).ToUpper().PadLeft(4, '0'), font, texto, 80 + n, 20);

                g.DrawString("D", font, texto, 11 + 120 + n, 5);
                g.DrawString(Convert.ToString(REG_D, b).ToUpper().PadLeft(4, '0'), font, texto, 120 + n, 20);

                g.DrawString("E", font, texto, 11 + 160 + n, 5);
                g.DrawString(Convert.ToString(REG_E, b).ToUpper().PadLeft(4, '0'), font, texto, 160 + n, 20);

                g.DrawString("F", font, texto, 11 + 200 + n, 5);
                g.DrawString(Convert.ToString(REG_F, b).ToUpper().PadLeft(4, '0'), font, texto, 200 + n, 20);

                g.DrawString("G", font, texto, 11 + 240 + n, 5);
                g.DrawString(Convert.ToString(REG_G, b).ToUpper().PadLeft(4, '0'), font, texto, 240 + n, 20);

                g.DrawString("H", font, texto, 11 + 280 + n, 5);
                g.DrawString(Convert.ToString(REG_H, b).ToUpper().PadLeft(4, '0'), font, texto, 280 + n, 20);



                g.DrawString("IP", font, texto, 7 + 350 + n, 5);
                g.DrawString(Convert.ToString(IP, b).ToUpper().PadLeft(4, '0'), font, texto, 350 + n, 20);

                g.DrawString("SP", font, texto, 7 + 390 + n, 5);
                g.DrawString(Convert.ToString(SP, b).ToUpper().PadLeft(4, '0'), font, texto, 390 + n, 20);



                g.DrawString("Zero", font, texto, 460 + n, 5);
                g.DrawString(Convert.ToString(FLG[0]), font, texto, 460 + n, 20);

                g.DrawString("Carry", font, texto, 510 + n, 5);
                g.DrawString(Convert.ToString(FLG[1]), font, texto, 510 + n, 20);

                g.DrawString("Input", font, texto, 560 + n, 5);
                g.DrawString(Convert.ToString(FLG[2]), font, texto, 560 + n, 20);

                g.DrawString("Fault", font, texto, 610 + n, 5);
                g.DrawString(Convert.ToString(FLG[3]), font, texto, 610 + n, 20);
            }
        }
        public void GraficarOUT_TEXT(Graphics g)
        {
            if (g != null)
            {
                Brush texto = new SolidBrush(Color.White);
                Font font = new Font("Consolas", 13.5f);

                g.Clear(Color.FromArgb(53, 73, 106));
                int _D = 7;

                for (int i = output_alloc_text; i - output_alloc_text < 32; i++)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(107, 110, 115)), (i - output_alloc_text) * 15 + 2 + _D, 7, 14, 22);
                    g.DrawString(((char)RAM[i]).ToString(), font, texto, (i - output_alloc_text) * 15 + 0 + _D, 7);
                }
            }
        }
        public void GraficarOUT_SCREEN(Graphics g)
        {

        }
        public bool GetFault()
        {
            return FLG[3];
        }

        public string SaveRAM()
        {
            string save = "";
            foreach (ushort g in RAM)
                save += ((char)g).ToString();
            return save;
        }
        public void SetRam(ref ushort[] RAM)
        {
            this.RAM = RAM;
        }

    }
    public class CompiladorRD1601
    {
        public List<int> pos_instrucciones { get; set; }
        public Dictionary<string, ushort> labels { get; set; }    //Guarda al momento de compilar, todas las etiquetas
        public List<KeyValuePair<string, ushort>> tempLabel { get; set; } //Guarda las etiquetas temporales al momento de compilar

        Sintaxis vSintactica = new Sintaxis();
        public string CompilarTexto(FastColoredTextBox txt, ref ushort[] RAM, string texto, List<int> pos_instrucciones, Dictionary<int, KeyValuePair<int, int>> lineas, List<KeyValuePair<int, int>> Dlineas)
        {
            List<string> palabras = ManejoTexto.ObtenerPalabras(texto);
            labels = new Dictionary<string, ushort>();
            tempLabel = new List<KeyValuePair<string, ushort>>();
            List<int> lineasReclamadas = new List<int>();       //Lineas ya usadas

            ushort ID = 0;
            bool check1 = false, check2 = false;

            for (int i = 0; i < palabras.Count; i++)
            {
                check1 = false; check2 = false;
                string palabra = palabras[i];
                string palabra_M = palabra.ToUpper();
                
                string palabra1 = "", palabra1_M = "", palabra2 = "", palabra2_M = "";

                if (i < palabras.Count - 1)
                {
                    palabra1 = palabras[i + 1];
                    palabra1_M = palabra1.ToUpper();
                }
                if (i < palabras.Count - 2)
                {
                    palabra2 = palabras[i + 2];
                    palabra2_M = palabra2.ToUpper();
                }
                
                Instruccion instruccion = vSintactica.GetInstruccion(palabra);
                if (palabra[palabra.Length - 1] == ':')
                {
                    for (int e = 0; e < Dlineas.Count; e++)
                    {
                        string sub = "";
                        if (!lineasReclamadas.Exists(x => x == e))
                        {
                            sub = texto.Substring(Dlineas[e].Key, Dlineas[e].Value);
                            if (sub.Contains(palabra))
                            {
                                txt.SelectionStart = Dlineas[e].Key;
                                txt.SelectionLength = Dlineas[e].Value;
                                txt.DoSelectionVisible();
                                break;
                            }
                        }
                    }
                    string n = palabra.Substring(0, palabra.Length - 1).ToUpper();

                    if (vSintactica.EsTermino(n, 1) == 1)
                        return "Can't use " + n + " as a label";
                    if (n.Length < 4)
                        return "4 letters or more for labels";


                    if (!vSintactica.InstruccionValida(n))
                    {
                        labels.Add(palabras[i].Substring(0, palabras[i].Length - 1), ID);
                        check1 = true;
                        continue;
                    }
                    else
                        return "Can't use " + n + " as a label";
                }

                if (instruccion == null)
                    throw new Exception("Instruction not found");

                int cantTerms = instruccion.terminos;
                for (int e = 0; e < Dlineas.Count; e++)
                {
                    string sub = "";
                    if (!lineasReclamadas.Exists(x => x == e))
                    {
                        sub = texto.Substring(Dlineas[e].Key, Dlineas[e].Value);
                        if (sub.Contains(palabras[i] + " "))
                        {
                            lineas.Add(ID, Dlineas[e]);
                            lineasReclamadas.Add(e);

                            txt.SelectionStart = Dlineas[e].Key;
                            txt.SelectionLength = Dlineas[e].Value;
                            txt.DoSelectionVisible();
                            break;
                        }
                    }
                }


                if (cantTerms == 2)
                {
                    if (vSintactica.EsTermino(palabra1, 1) == 0)
                        return palabra + " does not support [" + palabra1 + "] as first parameter";

                    if (vSintactica.EsTermino(palabra2, 2) == 0)
                        return palabra + " does not support [" + palabra2 + "] as second parameter";


                    RAM[ID + 0] = (ushort)((Operacion(palabra) << 8) | (Termino(palabra1, ID) << 4) | (Termino(palabra2, ID)));
                    RAM[ID + 1] = TerminoAValor(palabra1, (ushort)(ID + 1));
                    RAM[ID + 2] = TerminoAValor(palabra2, (ushort)(ID + 2));
                    pos_instrucciones.Add(ID);
                    ID += 3;
                    i += 2;
                    check2 = true;
                }
                else if (cantTerms == 1)
                {
                    if (palabra_M != "DB")
                    {
                        if (vSintactica.EsTermino(palabra1, 1) == 0 && (palabra1_M != "PUSH" && palabra1_M != "SETZ" && palabra1_M != "SETC" && palabra1_M != "SETI"))
                            return palabra + " does not support [" + palabra1 + "] as first parameter";

                        RAM[ID + 0] = (ushort)(Operacion(palabra) << 8 | Termino(palabra1, ID) << 4);
                        RAM[ID + 1] = TerminoAValor(palabra1, (ushort)(ID + 1));
                        pos_instrucciones.Add(ID);
                        i += 1;
                        ID += 2;
                        check2 = true;
                    }
                    else  //BD
                    {
                        ushort num;
                        if (!vSintactica.EsNumero(palabra1, out num) && palabra1[0] != '"' && palabra1[0] != '\'')
                            return palabra1 + " does not support this as first parameter";

                        if (vSintactica.EsNumero(palabra1, out num))
                        { RAM[ID++] = num; check2 = true; }
                        else
                        {
                            if (palabra1.Length >= 3)
                            {
                                if (palabra1[0] == '\'' && palabra1[palabra1.Length - 1] != '\'')
                                    return "Missing close [\']";
                                if (palabra1[0] != '\'' && palabra1[palabra1.Length - 1] == '\'')
                                    return "Missing open [\']";
                                if (palabra1[0] == '\"' && palabra1[palabra1.Length - 1] != '\"')
                                    return "Missing close [\"]";
                                if (palabra1[0] != '\"' && palabra1[palabra1.Length - 1] == '\"')
                                    return "Missing open [\"]";

                                if (palabra1[0] == '\'' && palabra1[palabra1.Length - 1] == '\'')
                                {
                                    if (palabra1.Length == 3)
                                    {
                                        RAM[ID++] = (ushort)palabra1[1];
                                        check2 = true;
                                    }
                                    else
                                        return "Wrong caracter format";
                                }
                                else if (palabra1[0] == '\"' && palabra1[palabra1.Length - 1] == '\"')
                                {
                                    string s = palabra1.Substring(1, palabra1.Length - 2);
                                    foreach (char c in s)
                                        RAM[ID++] = (byte)c;
                                    RAM[ID++] = 0;
                                    check2 = true;
                                }
                            }
                            else
                                return "Wrong data format";
                        }
                        i += 1;
                    }
                }
                else if (cantTerms == 0)
                {
                    RAM[ID] = (ushort)(Operacion(palabra) << 8);
                    pos_instrucciones.Add(ID);
                    ID += 1;
                    check2 = true;
                }
                if (check1 == false && check2 == false)
                    return "Sintaxis error, |" + palabras[i] + "| unknown";
            }
            txt.SelectionStart = 0;
            txt.SelectionLength = 0;
            txt.DoSelectionVisible();


            foreach (KeyValuePair<string, ushort> k in tempLabel)
            {


                if (labels.ContainsKey(k.Key))
                    RAM[k.Value] = labels[k.Key];
                else
                    return "Label not found: " + k.Key;
            }

            return "OK";
        }
        public void AgregarTerminoTemmpLabelSintx(string text, List<string> tempLabelSintx)
        {
            if (text[0] == '[')
            { tempLabelSintx.Add(text.Substring(1, text.Length - 2)); return; }

            tempLabelSintx.Add(text);
        }
  /*      public string ComprobarSintaxis(string texto, List<string> palabras, List<KeyValuePair<int, int>> Dlineas, ref int st, ref int l)
        {
            List<string> tempLabelSintx = new List<string>();   //Guarda, al momento de analizar sintacticamente el texto las etiquetas temporales
            List<string> LabelSintx = new List<string>();    //Guarda las etiquetas declaradas

            ManejoTexto.ObtenerPalabras(texto, palabras);
            bool check1 = false, check2 = false;

            for (int i = 0; i < palabras.Count; i++)
            {
                check1 = false; check2 = false;
                if (palabras[i][palabras[i].Length - 1] == ':')
                {
                    string n = palabras[i].Substring(0, palabras[i].Length - 1).ToUpper();

                    if (vSintactica.EsTermino(n, 1) == 1)
                        return "No se puede usar " + n + " como etiqueta";
                    if (n.Length < 3)
                        return "Las etiquetas deben tener 3 letras a más";


                    if (!vSintactica.InstruccionValida(n))
                    {
                        LabelSintx.Add(palabras[i].Substring(0, palabras[i].Length - 1));
                        check1 = true;
                        continue;
                    }
                    else
                        return "No se puede usar " + n + " como etiqueta";
                }

                int cantTerms = vSintactica.GetInstruccion(palabras[i]).terminos;
                if (cantTerms == 2)
                {
                    if (vSintactica.EsTermino(palabras[i + 1], 1) == 0)
                        return palabras[i] + " " + palabras[i + 1] + ", " + palabras[i + 2] + " no soporta este termino como primer operando";
                    if (vSintactica.EsTermino(palabras[i + 1], 1) == 2)
                        AgregarTerminoTemmpLabelSintx(palabras[i + 1], tempLabelSintx);

                    if (vSintactica.EsTermino(palabras[i + 2], 2) == 0)
                        return palabras[i] + " " + palabras[i + 1] + ", " + palabras[i + 2] + " no soporta este termino como segundo operando";
                    if (vSintactica.EsTermino(palabras[i + 2], 2) == 2)
                        AgregarTerminoTemmpLabelSintx(palabras[i + 2], tempLabelSintx);

                    i += 2;
                    check2 = true;
                }
                else if (cantTerms == 1)
                {
                    if (palabras[i].ToUpper() != "DB")
                    {
                        string n = palabras[i + 1];
                        string up = palabras[i].ToUpper();
                        if (vSintactica.EsTermino(palabras[i + 1], 1) == 0 && (up != "PUSH" && up != "SETZ" && up != "SETC" && up != "SETI" && up != "SETM"))
                            return palabras[i] + " " + palabras[i + 1] + " no soporta este termino como primer operando";
                        if (vSintactica.EsTermino(palabras[i + 1], 1) == 2)
                            AgregarTerminoTemmpLabelSintx(palabras[i + 1], tempLabelSintx);

                        i += 1;
                        check2 = true;
                    }
                    else  //BD
                    {
                        ushort num;
                        if (!vSintactica.EsNumero(palabras[i + 1], out num) && palabras[i + 1][0] != '"' && palabras[i + 1][0] != '\'')
                            return palabras[i] + " " + palabras[i + 1] + " no soporta este termino como primer operando";

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

            foreach (string k in tempLabelSintx)
                if (LabelSintx.Exists(x => x == k))
                    continue;
                else
                { return "Etiqueta no encontrada:  " + k; }

            return "OK";
        }
*/
        #region Compilación
        public ushort TerminoAValor(string text, ushort ID)
        {
            string original = text;
            text = text.ToUpper();

            if (labels.ContainsKey(original))
                return labels[original];

            ushort num = 0;
            if (vSintactica.EsNumero(original, out num))
                return num;

            if (text == "A" || text == "[A]") return 0;
            if (text == "B" || text == "[B]") return 1;
            if (text == "C" || text == "[C]") return 2;
            if (text == "D" || text == "[D]") return 3;
            if (text == "E" || text == "[E]") return 4;
            if (text == "F" || text == "[F]") return 5;
            if (text == "G" || text == "[G]") return 6;
            if (text == "H" || text == "[H]") return 7;
            if (text == "SP" || text == "[SP]") return 8;
            if (text == "IP" || text == "[IP]") return 9;

            if (text.Length >= 3)
            {
                if (vSintactica.EsNumero(text.Substring(1, text.Length - 2), out num))
                    return num;
                if (labels.ContainsKey(original.Substring(1, original.Length - 2)))
                    return labels[original.Substring(1, original.Length - 2)];

                if (original[0] == '[' && original[original.Length - 1] == ']')
                {
                    tempLabel.Add(new KeyValuePair<string, ushort>(original.Substring(1, original.Length - 2), ID));
                    return 255;
                }

                if (original[0] == '\'' && original[original.Length - 1] == '\'')
                {
                    return (ushort)original[1];
                }
            }

            tempLabel.Add(new KeyValuePair<string, ushort>(original, ID));
            return 255;
        }
        public ushort Operacion(string inst)
        {
            return vSintactica.GetInstruccion(inst).value;
        }
        public ushort Termino(string text, ushort ID)
        {
            ushort num;
            bool reg = false, ram = false, ramr = false, con = false;

            string original = text;
            text = text.ToUpper();

            if (labels.ContainsKey(original))
                con = true;

            if (text == "A" || text == "B" || text == "C" || text == "D" || text == "E" || text == "F" || text == "G" || text == "H" || text == "SP" || text == "IP")
                reg = true;
            else if (text == "[A]" || text == "[B]" || text == "[C]" || text == "[D]" || text == "[E]" || text == "[F]" || text == "[G]" || text == "[H]" || text == "[SP]" || text == "[IP]")
                ramr = true;
            else if (text.Length >= 3)
            {
                if (text[0] == '[' && text[text.Length - 1] == ']')
                {
                    if (vSintactica.EsNumero(original.Substring(1, original.Length - 2), out num))
                        ram = true;
                    else if (labels.ContainsKey(original.Substring(0, original.Length - 2)))
                        ram = true;
                }
            }
            if (vSintactica.EsNumero(text, out num))
                con = true;

            if (!(reg || ram || ramr || con))
            {
                if (original.Length >= 3)
                {
                    if (original[0] == '[' && original[original.Length - 1] == ']')
                    {
                        tempLabel.Add(new KeyValuePair<string, ushort>(original.Substring(1, original.Length - 2), (ushort)(ID + 1)));
                        ram = true;
                    }
                }
            }

            if (reg) return 1;
            if (ram) return 2;
            if (ramr) return 3;
            if (con) return 4;

            return 4;
        }
        #endregion
    }
    public class EditorRD1601
    {
        CompiladorRD1601 compilador = new CompiladorRD1601();
        public OrdenadorRD1601 ordenador { get; set; }
        FastColoredTextBox txt;
        ListView lstv;
        public ushort[] IMG { get; set; }
        public ushort alloc_img { get; set; }

        public EditorRD1601(FastColoredTextBox txt, ListView lstv)
        {
            this.txt = txt;
            this.lstv = lstv;
            IMG = new ushort[512];
            ordenador = new OrdenadorRD1601();
            alloc_img = 64768;
        }
        public bool EjecutarInstruccion()
        {
            int i = 0, f = 0;
            bool ans = ordenador.EjecutarInstruccion(ref i, ref f);
            txt.SelectionStart = i;
            txt.SelectionLength = f;
            txt.DoSelectionVisible();
            return ans;
        }
        public bool Compilar(ref string respuesta)
        {
            List<string> palabras = new List<string>();
            Dictionary<int, KeyValuePair<int, int>> lineas = new Dictionary<int, KeyValuePair<int, int>>(); //Lineas importantes
            List<KeyValuePair<int, int>> Dlineas = ManejoTexto.ObtenerLineas(txt.Text);        //Todas las lineas
            List<int> pos_instrucciones = new List<int>();
            
            ushort[] RAM = new ushort[0x10000];
            string ans = compilador.CompilarTexto(txt, ref RAM, txt.Text, pos_instrucciones, lineas, Dlineas);
            if (ans == "OK")
            {
                for (int i = alloc_img; i - alloc_img < 0x200; i++)
                    RAM[i] = IMG[i - alloc_img];

                ordenador.Reset();
                ordenador.pos_instrucciones = pos_instrucciones;
                ordenador.lineas = lineas;
                ordenador.SetRam(ref RAM);

                lstv.Clear();

                lstv.Columns.Add("Name", (int)(2 * lstv.Width / 5 - 1));
                lstv.Columns.Add("Address", (int)(1.5 * lstv.Width / 5 - 1));
                lstv.Columns.Add("Value", (int)(1.5 * lstv.Width / 5 - 1) - 16);

                foreach (var a in compilador.labels)
                {
                    ListViewItem row = new ListViewItem(a.Key);
                    row.SubItems.Add("0x" + Convert.ToString(a.Value, 16).ToUpper().PadLeft(4, '0'));
                    ushort value = RAM[a.Value];
                    if (value < 32 || value > 126)
                        row.SubItems.Add("0x" + Convert.ToString(value, 16).ToUpper().PadLeft(4, '0'));
                    else
                        row.SubItems.Add("\'" + (char)value + "\'");


                    lstv.Items.Add(row);

                }
                    return true;
            }
            else
            {
                respuesta = ans;
            }
            return false;
        }
        public void Graficar(Graphics reg, Graphics ram, Graphics out_text, int page, bool output)
        {
            ordenador.GraficarRAM(ram, page, output);
            ordenador.GraficarREG(reg);
            ordenador.GraficarOUT_TEXT(out_text);
        }

        public void ObtenerImagenes(Graphics g)
        {
            if (g != null)
            {
                int ancho = (int)(g.VisibleClipBounds.Width / 8 / 16);
                int alto = (int)(g.VisibleClipBounds.Height / 4 / 16);

                g.Clear(Color.White);
                Brush br = Brushes.Black;

                for (int i = 0; i < 512; i++)
                {
                    int x = (i / 16) % 8;
                    int y = (i / 128);
                    int desf_y = alto * (i % 16);

                    if (((IMG[i] & 32768) >> 15) == 1) g.FillRectangle(br, x * ancho * 16 + ancho *  0, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] & 16384) >> 14) == 1) g.FillRectangle(br, x * ancho * 16 + ancho *  1, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &  8192) >> 13) == 1) g.FillRectangle(br, x * ancho * 16 + ancho *  2, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &  4096) >> 12) == 1) g.FillRectangle(br, x * ancho * 16 + ancho *  3, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &  2048) >> 11) == 1) g.FillRectangle(br, x * ancho * 16 + ancho *  4, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &  1024) >> 10) == 1) g.FillRectangle(br, x * ancho * 16 + ancho *  5, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &   512) >>  9) == 1) g.FillRectangle(br, x * ancho * 16 + ancho *  6, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &   256) >>  8) == 1) g.FillRectangle(br, x * ancho * 16 + ancho *  7, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &   128) >>  7) == 1) g.FillRectangle(br, x * ancho * 16 + ancho *  8, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &    64) >>  6) == 1) g.FillRectangle(br, x * ancho * 16 + ancho *  9, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &    32) >>  5) == 1) g.FillRectangle(br, x * ancho * 16 + ancho * 10, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &    16) >>  4) == 1) g.FillRectangle(br, x * ancho * 16 + ancho * 11, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &     8) >>  3) == 1) g.FillRectangle(br, x * ancho * 16 + ancho * 12, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &     4) >>  2) == 1) g.FillRectangle(br, x * ancho * 16 + ancho * 13, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &     2) >>  1) == 1) g.FillRectangle(br, x * ancho * 16 + ancho * 14, y * (alto * 16) + desf_y, ancho, alto);
                    if (((IMG[i] &     1) >>  0) == 1) g.FillRectangle(br, x * ancho * 16 + ancho * 15, y * (alto * 16) + desf_y, ancho, alto);
                }
                for (int x = 1; x < 8; x++)
                    g.DrawLine(Pens.Red, x * ancho * 16, 0, x * ancho * 16, alto * 16 * 4);

                for (int y = 1; y < 4; y++)
                    g.DrawLine(Pens.Red, 0, y * alto * 16, 16 * ancho * 8, alto * 16 * y);
            }
        }
        public void ObtenerSprite(Graphics g, int x, int y)
        {
            if (g != null)
            {
                int pos = (x * 16) + (y * 16 * 8);
                int ancho = (int)(g.VisibleClipBounds.Width / 16f);
                int alto = (int)(g.VisibleClipBounds.Height / 16f);

                g.Clear(Color.White);
                Brush br = Brushes.Black;

                for (int i = pos; i - pos < 16; i++)
                {
                    int desf_y = alto * (i % 16);

                    if (((IMG[i] & 32768) >> 15) == 1) g.FillRectangle(br, ancho *  0, desf_y, ancho, alto);
                    if (((IMG[i] & 16384) >> 14) == 1) g.FillRectangle(br, ancho *  1, desf_y, ancho, alto);
                    if (((IMG[i] &  8192) >> 13) == 1) g.FillRectangle(br, ancho *  2, desf_y, ancho, alto);
                    if (((IMG[i] &  4096) >> 12) == 1) g.FillRectangle(br, ancho *  3, desf_y, ancho, alto);
                    if (((IMG[i] &  2048) >> 11) == 1) g.FillRectangle(br, ancho *  4, desf_y, ancho, alto);
                    if (((IMG[i] &  1024) >> 10) == 1) g.FillRectangle(br, ancho *  5, desf_y, ancho, alto);
                    if (((IMG[i] &   512) >>  9) == 1) g.FillRectangle(br, ancho *  6, desf_y, ancho, alto);
                    if (((IMG[i] &   256) >>  8) == 1) g.FillRectangle(br, ancho *  7, desf_y, ancho, alto);
                    if (((IMG[i] &   128) >>  7) == 1) g.FillRectangle(br, ancho *  8, desf_y, ancho, alto);
                    if (((IMG[i] &    64) >>  6) == 1) g.FillRectangle(br, ancho *  9, desf_y, ancho, alto);
                    if (((IMG[i] &    32) >>  5) == 1) g.FillRectangle(br, ancho * 10, desf_y, ancho, alto);
                    if (((IMG[i] &    16) >>  4) == 1) g.FillRectangle(br, ancho * 11, desf_y, ancho, alto);
                    if (((IMG[i] &     8) >>  3) == 1) g.FillRectangle(br, ancho * 12, desf_y, ancho, alto);
                    if (((IMG[i] &     4) >>  2) == 1) g.FillRectangle(br, ancho * 13, desf_y, ancho, alto);
                    if (((IMG[i] &     2) >>  1) == 1) g.FillRectangle(br, ancho * 14, desf_y, ancho, alto);
                    if (((IMG[i] &     1) >>  0) == 1) g.FillRectangle(br, ancho * 15, desf_y, ancho, alto);
                }
                for (int i = 1; i < 17; i++)
                    g.DrawLine(Pens.Green, i * ancho, 0, i * ancho, alto * i * 17);

                for (int i = 1; i < 17; i++)
                    g.DrawLine(Pens.Green, 0, i * alto, 17 * ancho, alto * i);
            }
        }
        public void DefinirImagenes(int x, int y, int pxl_x, int pxl_y, int value)
        {
            int pos = (x * 16) + (y * 8 * 16) + pxl_y;

            switch (pxl_x % 16)
            {
                case  0: IMG[pos] = (ushort)((IMG[pos] & 32767) | (value << 15)); break;
                case  1: IMG[pos] = (ushort)((IMG[pos] & 49151) | (value << 14)); break;
                case  2: IMG[pos] = (ushort)((IMG[pos] & 57343) | (value << 13)); break;
                case  3: IMG[pos] = (ushort)((IMG[pos] & 61439) | (value << 12)); break;
                case  4: IMG[pos] = (ushort)((IMG[pos] & 63487) | (value << 11)); break;
                case  5: IMG[pos] = (ushort)((IMG[pos] & 64511) | (value << 10)); break;
                case  6: IMG[pos] = (ushort)((IMG[pos] & 65023) | (value <<  9)); break;
                case  7: IMG[pos] = (ushort)((IMG[pos] & 65279) | (value <<  8)); break;
                case  8: IMG[pos] = (ushort)((IMG[pos] & 65407) | (value <<  7)); break;
                case  9: IMG[pos] = (ushort)((IMG[pos] & 65471) | (value <<  6)); break;
                case 10: IMG[pos] = (ushort)((IMG[pos] & 65503) | (value <<  5)); break;
                case 11: IMG[pos] = (ushort)((IMG[pos] & 65519) | (value <<  4)); break;
                case 12: IMG[pos] = (ushort)((IMG[pos] & 65527) | (value <<  3)); break;
                case 13: IMG[pos] = (ushort)((IMG[pos] & 65531) | (value <<  2)); break;
                case 14: IMG[pos] = (ushort)((IMG[pos] & 65533) | (value <<  1)); break;
                case 15: IMG[pos] = (ushort)((IMG[pos] & 65534) | (value <<  0)); break;
            }
        }
    }
}