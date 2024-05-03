namespace Progra620241_Assets_JosueVargasM2.ModelsDTO
{
    public class UserDTO
    {
        //Un dto (data transfer object) sirve para varios objetivos.

        //1.desacoplcar el modelo de la funcionalidad de los controladores
        //.parta eviatr que en futuras actualizaciones de los modelos
        // puedan ocurrir errores dificles de reparar 

        //2. sirvre para simplificar modelos muy complejos y que tienen
        //composiciones recursivas , muy comunes cuando se genran
        //mediante ORM(mecanismo que facvilita la cimunicaicon con la bdy reaizar los modelos)

        //3.pr un asunto de seguridad, ya que, normnalmente los equipos 
        // de desarrollo de las appps y web api estan separados y no
        //se quiere que los rogramadors de front serpan como esrta 
        //estructurada la base de datos tomando como base los modelos.

        public int CodigoUsuario { get; set; }

        public string Cedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string Correo { get; set; } = null!;

        //em este ejemplono usaremos la contrasena ya que este DTO
        //sera usado para mostrar la lista de usuarios de una UI
        //tendremos otra version de DTO que si tiene la contrasennia
        //para cuando querramos agregar un usuario

        //public string Contrasennia { get; set; } = null!;

        public bool? Activo { get; set; }

        public int CodigoDeRol { get; set; }
        public string? RoldeUsuario { get; set; }

        public string? NotasDeUsuario { get; set; }

        //aca se pueden agregar los atributos que sean necesarios

    }
}
