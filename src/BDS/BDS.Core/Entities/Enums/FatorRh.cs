namespace BDS.Core.Entities.Enums
{
    /// <summary>
    /// Cada tipo sanguíneo é caracterizado pela presença ou pela ausência de determinados antígenos nos glóbulos vermelhos. A presença de aglutinogênio A, de aglutinogênio B, de aglutinogênio A e B e a ausência desses aglutinogênios vão especificar o tipo de sangue de cada indivíduo.
    /// <see href="https://amigosdaoncologia.org.br/navegacaodepacientes/noticias/voce-sabe-qual-o-seu-tipo-de-sangue-e-o-fator-rh"/>
    /// </summary>
    public enum FatorRh
    {
        Negativo = 0,
        Positivo = 1
    }
}
