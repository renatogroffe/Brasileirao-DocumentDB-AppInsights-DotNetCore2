namespace CargaDadosBrasileirao
{
    public class SeleniumConfigurations
    {
        public string CaminhoDriverFirefox { get; set; }
        public string UrlPaginaClassificacaoBrasileirao { get; set; }
        public int Timeout { get; set; }
    }

    public class DocumentDBConfigurations
    {
        public string EndpointUri { get; set; }
        public string PrimaryKey { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
}