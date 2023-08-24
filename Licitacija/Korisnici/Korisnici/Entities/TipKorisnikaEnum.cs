using System.ComponentModel;

namespace Korisnici.Entities
{
    /// <summary>
    /// Entitet Tip korisnika koji je predstavljen enumeratorom
    /// </summary>
    public enum TipKorisnikaEnum
    {
        /// <summary>
        /// Tip korisnika operater
        /// </summary>
        Operater,
        /// <summary>
        /// Tip korisnika tehnicki sekretar
        /// </summary>
        Tehnicki_sekretar,
        /// <summary>
        /// Tip korisnika prva komisija
        /// </summary>
        Prva_komisija,
        /// <summary>
        /// Tip korisnika superuser
        /// </summary>
        Superuser,
        /// <summary>
        /// Tip korisnika operater nadmetanja
        /// </summary>
        Operater_nadmetanja,
        /// <summary>
        /// Tip korisnika licitant
        /// </summary>
        Licitatnt,
        /// <summary>
        /// Tip korisnika menadzer
        /// </summary>
        Menadzer,
        /// <summary>
        /// Tip korisnika administrator
        /// </summary>
        Administrator
    }
}
