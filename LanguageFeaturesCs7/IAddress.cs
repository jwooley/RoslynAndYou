namespace LanguageFeaturesCs7
{
    public interface IAddress
    {
        string Address1 { get; set; }
        //string Address2 { get;  set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }

        // Default interface implementation
//        string Formatted()
//        {
//            return $@"{Address1}
//{Address2}
//{City}, {State} {Zip}";
//        }
    }
}