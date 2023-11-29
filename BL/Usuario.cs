using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaPruebaExamenEntities1 conntext = new DL.JGarciaPruebaExamenEntities1())
                {
                    var query = conntext.UsuarioGetAll().ToList();

                    if(query!= null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Nombre = item.Nombre;
                            usuario.Apellido = item.Apellido;
                            usuario.Edad = item.Edad.Value;
                            usuario.FechaIngreso = item.FechaIngreso.Value;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaPruebaExamenEntities1 context = new DL.JGarciaPruebaExamenEntities1())
                {
                    var query = context.UsuarioGetById(IdUsuario).SingleOrDefault();

                    result.Object = new List<object>();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.Apellido = query.Apellido;
                        usuario.Edad = query.Edad.Value;
                        usuario.FechaIngreso = query.FechaIngreso.Value;

                        result.Correct = true;
                        result.Object = usuario;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch(Exception e)
            {
                result.ErrorMessage = e.Message;
                result.Ex = e;
                result.Correct = false;
            }
            return result;
        }


        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaPruebaExamenEntities1 context = new DL.JGarciaPruebaExamenEntities1())
                {
                    var rowAffected = context.UsuarioAdd(usuario.Nombre, usuario.Apellido, usuario.Edad, usuario.FechaIngreso);

                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGarciaPruebaExamenEntities1 context = new DL.JGarciaPruebaExamenEntities1())
                {
                    var rowAffected = context.UsuarioUpdate(usuario.IdUsuario,
                                                            usuario.Nombre,
                                                            usuario.Apellido,
                                                            usuario.Edad,
                                                            usuario.FechaIngreso);
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result=new ML.Result();
            try
            {
                using (DL.JGarciaPruebaExamenEntities1 context = new DL.JGarciaPruebaExamenEntities1())
                {
                    int rowAffected = context.UsuarioDelete(IdUsuario);

                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMessage=ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
    }
}
