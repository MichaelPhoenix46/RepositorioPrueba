using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webApp_Mono_UCNE_2_2020.Clases
{
	public class ErrorResponse
	{
		public int ID { get; set; }

		public bool OK { get; set; }
		private readonly StringBuilder descripcion;
		public string Descripcion
		{
			get
			{
				return descripcion.ToString();
			}
		}


		public ErrorResponse()
		{
			ID = 0;
			descripcion = new StringBuilder();
			OK = false;
		}

		public void AddDescripcion(string mensaje)
		{
			descripcion.Append(mensaje);
		}

		public static ErrorResponse ReturnValues(int id, string mensaje)
		{
			ErrorResponse error = new ErrorResponse
			{
				ID = id
			};
			error.AddDescripcion(mensaje);
			return error;
		}
		public static ErrorResponse ReturnValues(bool valor, string mensaje)
		{
			ErrorResponse error = new ErrorResponse
			{
				OK = valor,
				ID = 0
			};
			error.AddDescripcion(mensaje);
			return error;
		}
		public static ErrorResponse ReturnValues(bool valor, int numeroError, string mensaje)
		{
			ErrorResponse error = new ErrorResponse
			{
				OK = valor,
				ID = numeroError
			};
			error.AddDescripcion(mensaje);
			return error;
		}

		public void SetValues(bool valor, string mensaje)
		{
			this.ID = 0;
			this.OK = valor;
			this.AddDescripcion(mensaje);
		}
		public void SetValues(bool valor, int numeroError, string mensaje)
		{
			this.ID = numeroError;
			this.OK = valor;
			this.AddDescripcion(mensaje);
		}
		public void SetValues(int numeroError, string mensaje)
		{
			this.ID = numeroError;
			this.OK = false;
			this.AddDescripcion(mensaje);
		}
	}
}
