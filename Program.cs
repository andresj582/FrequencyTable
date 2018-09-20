using System;

namespace FrequencyTable
{
    class Program
    {   
        static double GetMediana(double[,] _p_tablaFr, double _p_clase, double _p_n, double[,] _P_MediaVarianza)
        {
            double _return, _LLmediana, _Fanterior, _fmedia;
			 _return = _LLmediana = _Fanterior = _fmedia  = 0;
			double _media = GetMedia(_p_tablaFr, _p_clase, _p_n);
			
			for(int i=0; i<_p_clase; i++)
			{
				if( _p_tablaFr[2,i] >= _media)
				{
					_LLmediana = _p_tablaFr[1,i];
					_Fanterior = _p_tablaFr[6,i-1];
				}
			}
			
            return _return;
        }
        static double GetMedia(double[,] _p_tablaFr, double _p_clase, double _p_n)
        {
            double _acumulador = 0;
            for (int i = 0; i < _p_clase; i++)
            {
                _acumulador += _p_tablaFr[4, i] * _p_tablaFr[3, i];
            }
            double _return = _acumulador / _p_n;
            Console.Write(_acumulador + " / " + _p_n + " = " + _return);

            return _return;
        }
		
        static double GetMedia( double[,] _p_tablaFr, double _p_clase, double _p_n, double[,] _P_MediaVarianza)
        {
            double _acumulador = 0;
            for(int i=0; i<_p_clase; i++)
            {
                _acumulador += _p_tablaFr[4,i] * _p_tablaFr[3,i];
                _P_MediaVarianza[0,i] = _p_tablaFr[4, i] * _p_tablaFr[3, i];
            }
            double _return = _acumulador / _p_n;
            //Console.WriteLine(_acumulador +" / "+ _p_n+" = "+_return);
            
            return _return;
        }

        static void ImprimirTabla(double[,] _p_Tabla, int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    ColorColumn(j);
                    Console.Write(_p_Tabla[j, i] + " - ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        static void ColorColumn(int _p_i = 0)
        {
            switch(_p_i)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        static void Main(string[] args)
        {

            double _Xmax, _Xmin, _n, _Rango, _Clase, _Anchointervalo;
            _Xmax = _Xmin = _Rango = _Clase = _Anchointervalo =0;

            Console.Write("Tamaño de la muestra: ");
            _n = Double.Parse(Console.ReadLine());

            double[] _datos = new double[(int) _n];
            
            /*
            for(short i=0; i<_n; i++)
            {
                Console.Write("digite el dato #"+(i+1));
            }
            */

            Console.Write("Valor máximo: ");
            _Xmax = int.Parse(Console.ReadLine());
            Console.Write("Valor mínimo: ");
            _Xmin = int.Parse(Console.ReadLine());

            //calculo del rango
            _Rango = _Xmax - _Xmin;
            Console.WriteLine("Rango = "+_Rango +"\n");

            //calculo de la clase (k)
            _Clase = (1 + (3.322 * Math.Log10(_n)));
            Console.WriteLine("Clase (k) = "+ _Clase);
            //aproximacion
            _Clase = Math.Round(_Clase);
            Console.WriteLine("Clase (valor aproximado) = "+ _Clase+"\n");

            //calculo del ancho del intervalo
            _Anchointervalo = _Rango / _Clase;
            Console.WriteLine("Ancho del intervalo (h) = "+ _Anchointervalo);
            //aproximacion
            _Anchointervalo = _Anchointervalo > Math.Round(_Anchointervalo) 
            ? Math.Round(_Anchointervalo) +1 
            : Math.Round(_Anchointervalo);
            Console.WriteLine("(valor aproximado) = "+ _Anchointervalo+"\n");
            
            double[,] _Tablafrecuencia = new double[8, (int)(_Clase)];
            double _Li = _Xmin;
            for(int i=0; i<_Clase; i++)
            {   
                _Tablafrecuencia[0,i] = (i+1);
                _Tablafrecuencia[1,i] = _Li;
                //Console.WriteLine("Li clase "+(_Tablafrecuencia[0,i])+" = "+_Tablafrecuencia[1,i]);
                _Li += _Anchointervalo;
            }
            Console.WriteLine();
            _Li = _Xmin+_Anchointervalo;
            for(int i=0; i<_Clase; i++)
            {   
                _Tablafrecuencia[2,i] = _Li;
                //Console.WriteLine("Ls clase "+(i)+" = "+_Tablafrecuencia[2,i]);
                _Li += _Anchointervalo;
            }
            Console.WriteLine();
            for(int i=0; i<_Clase; i++)
            {
                _Tablafrecuencia[3,i] = (_Tablafrecuencia[2,i] + _Tablafrecuencia[1,i]) / 2;
                //Console.WriteLine("Pm clase "+(i)+" = "+_Tablafrecuencia[3,i]);
            }
            Console.WriteLine();
            for(int i=0; i<_Clase; i++)
            {
                Console.Write("Frecuencia clase "+(i+1)+": ");
                _Tablafrecuencia[4,i] = Double.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            for(int i=0; i<_Clase; i++)
            {
                _Tablafrecuencia[5,i] = (_Tablafrecuencia[4,i]) / _n;
                //Console.WriteLine("fr clase "+(i)+" = "+_Tablafrecuencia[5,i]);
            }
            Console.WriteLine();
            double _acumulador = 0;
            for(int i=0; i<_Clase; i++)
            {   
                _acumulador += _Tablafrecuencia[ 4, i];
                _Tablafrecuencia[6, i] = _acumulador;
                //Console.WriteLine("F clase "+(i)+" = "+_Tablafrecuencia[6,i]);
            }
            Console.WriteLine();
            _acumulador = 0;
            for(int i=0; i<_Clase; i++)
            {   
                _acumulador += _Tablafrecuencia[ 5, i];
                _Tablafrecuencia[7, i] = _acumulador;
                //Console.WriteLine("FR clase "+(i)+" = "+_Tablafrecuencia[7,i]);
            }
            ImprimirTabla( _Tablafrecuencia, 8, (int)_Clase);
            
            double[,] _MediaVarianza = new double[4 , (int) _Clase];
            ColorColumn();

            GetMedia(_Tablafrecuencia, _Clase, _n, _MediaVarianza);

            ImprimirTabla( _MediaVarianza, 4, (int) _Clase);
            GetMedia(_Tablafrecuencia, _Clase, _n);
            GetMediana(_Tablafrecuencia, _Clase, _n, _MediaVarianza);
			
			
            Console.ReadKey();

        }
    }
}
