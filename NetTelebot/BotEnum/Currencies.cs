namespace NetTelebot.BotEnum
{
    /// <summary>
    /// Telegram payments currently support the currencies enum below.
    /// If you're using Stripe as the payments provider, supported currencies may vary depending on the 
    /// country you have specified in your Stripe account (more info).
    /// The minimum and maximum amounts for each of the currencies roughly correspond to the limit of US$ 1-10000.
    /// The amount must be expressed in 8 digits or less, so the maximum value will be correspondingly lower for 
    /// some lower-value currencies like the Serbian dinar.
    /// Note that for each currency except USD these limits depend on exchange rates and may change over time 
    /// (plan ahead for this when you implement limits in your code).
    /// </summary>
    public enum Currencies
    {
        /// <summary>
        /// United Arab Emirates Dirham
        /// </summary>
        AED,

        /// <summary>
        /// Afghan Afghani
        /// </summary>
        AFN,

        /// <summary>
        /// Albanian Lek
        /// </summary>
        ALL,

        /// <summary>
        /// Аrmenian Dram
        /// </summary>
        AMD,

        /// <summary>
        /// Argentine Peso
        /// </summary>
        ARS,

        /// <summary>
        /// Australian Dollar
        /// </summary>
        AUD,

        /// <summary>
        /// Azerbaijani Manat
        /// </summary>
        AZN,

        /// <summary>
        /// Bosnia & Herzegovina Convertible Mark
        /// </summary>
        BAM,

        /// <summary>
        /// Bangladeshi Taka
        /// </summary>
        BDT,

        /// <summary>
        /// Bulgarian Lev
        /// </summary>
        BGN,

        /// <summary>
        /// Brunei Dollar
        /// </summary>
        BND,

        /// <summary>
        /// Bolivian Boliviano
        /// </summary>
        BOB,

        /// <summary>
        /// Brazilian Real
        /// </summary>
        BPL,

        /// <summary>
        /// Canadian Dollar
        /// </summary>
        CAD,

        /// <summary>
        /// Swiss Franc
        /// </summary>
        CHF,

        /// <summary>
        /// Chilean Peso
        /// </summary>
        CLP,

        /// <summary>
        /// Chinese Renminbi Yuan
        /// </summary>
        CNY,

        /// <summary>
        /// Colombian Peso
        /// </summary>
        COP,

        /// <summary>
        /// Costa Rican Colón
        /// </summary>
        CRC,

        /// <summary>
        /// Czech Koruna
        /// </summary>
        CZK,

        /// <summary>
        /// Danish Krone
        /// </summary>
        DKK,

        /// <summary>
        /// Dominican Peso
        /// </summary>
        DOP,

        /// <summary>
        /// Algerian Dinar
        /// </summary>
        DZD,

        /// <summary>
        /// Egyptian Pound
        /// </summary>
        EGP,

        /// <summary>
        /// Euro
        /// </summary>
        EUR,

        /// <summary>
        /// British Pound
        /// </summary>
        GBP,

        /// <summary>
        /// Georgian Lari
        /// </summary>
        GEL,

        /// <summary>
        /// Guatemalan Quetzal
        /// </summary>
        GTQ,

        /// <summary>
        /// Hong Kong Dollar
        /// </summary>
        HKD,

        /// <summary>
        /// Honduran Lempira
        /// </summary>
        HNL,

        /// <summary>
        /// Croatian Kuna
        /// </summary>
        HRK,

        /// <summary>
        /// Hungarian Forint
        /// </summary>
        HUF,

        /// <summary>
        /// Indonesian Rupiah
        /// </summary>
        IDR,

        /// <summary>
        /// Israeli New Sheqel
        /// </summary>
        ILS,

        /// <summary>
        /// Indian Rupee
        /// </summary>
        INR,

        /// <summary>
        /// Icelandic Króna
        /// </summary>
        ISK,

        /// <summary>
        /// Jamaican Dollar
        /// </summary>
        JMD,

        /// <summary>
        /// Japanese Yen
        /// </summary>
        JPY,

        /// <summary>
        /// Kenyan Shilling
        /// </summary>
        KES,

        /// <summary>
        /// Kyrgyzstani Som
        /// </summary>
        KGS,

        /// <summary>
        /// South Korean Won
        /// </summary>
        KRW,

        /// <summary>
        /// Kazakhstani Tenge
        /// </summary>
        KZT,

        /// <summary>
        /// Lebanese Pound
        /// </summary>
        LBP,

        /// <summary>
        /// Sri Lankan Rupee
        /// </summary>
        LKR,

        /// <summary>
        /// Moroccan Dirham
        /// </summary>
        MAD,

        /// <summary>
        /// Moldovan Leu
        /// </summary>
        MDL,

        /// <summary>
        /// Mongolian Tögrög
        /// </summary>
        MNT,

        /// <summary>
        /// Mauritian Rupee
        /// </summary>
        MUR,

        /// <summary>
        /// Maldivian Rufiyaa
        /// </summary>
        MVR,

        /// <summary>
        /// Mexican Peso
        /// </summary>
        MXN,

        /// <summary>
        /// Malaysian Ringgit
        /// </summary>
        MYR,

        /// <summary>
        /// Mozambican Metical
        /// </summary>
        MZN,

        /// <summary>
        /// Nigerian Naira
        /// </summary>
        NGN,

        /// <summary>
        /// Nicaraguan Córdoba
        /// </summary>
        NIO,

        /// <summary>
        /// Norwegian Krone
        /// </summary>
        NOK,

        /// <summary>
        /// Nepalese Rupee
        /// </summary>
        NPR,

        /// <summary>
        /// New Zealand Dollar
        /// </summary>
        NZD,

        /// <summary>
        /// Panamanian Balboa
        /// </summary>
        PAB,

        /// <summary>
        /// Peruvian Nuevo Sol
        /// </summary>
        PEN,

        /// <summary>
        /// Philippine Peso
        /// </summary>
        PHP,

        /// <summary>
        /// Pakistani Rupee
        /// </summary>
        PKR,

        /// <summary>
        /// Polish Złoty
        /// </summary>
        PLN,

        /// <summary>
        /// Paraguayan Guaraní
        /// </summary>
        PYG,

        /// <summary>
        /// Qatari Riyal
        /// </summary>
        QAR,

        /// <summary>
        /// Romanian Leu
        /// </summary>
        RON,

        /// <summary>
        /// Serbian Dinar
        /// </summary>
        RSD,

        /// <summary>
        /// Russian Ruble
        /// </summary>
        RUB,

        /// <summary>
        /// Saudi Riyal
        /// </summary>
        SAR,

        /// <summary>
        /// Swedish Krona
        /// </summary>
        SEK,

        /// <summary>
        /// Singapore Dollar
        /// </summary>
        SGD,

        /// <summary>
        /// Thai Baht
        /// </summary>
        THB,

        /// <summary>
        /// Tajikistani Somoni
        /// </summary>
        TJS,

        /// <summary>
        /// Turkish Lira
        /// </summary>
        TRY,

        /// <summary>
        /// Trinidad and Tobago Dollar
        /// </summary>
        TTD,

        /// <summary>
        /// New Taiwan Dollar
        /// </summary>
        TWD,

        /// <summary>
        /// Tanzanian Shilling
        /// </summary>
        TZS,

        /// <summary>
        /// Ukrainian Hryvnia
        /// </summary>
        UAH,

        /// <summary>
        /// Ugandan Shilling
        /// </summary>
        UGX,

        /// <summary>
        ///  	United States Dollar
        /// </summary>
        USD,

        /// <summary>
        /// Uruguayan Peso
        /// </summary>
        UYU,

        /// <summary>
        /// Uzbekistani Som
        /// </summary>
        UZS,

        /// <summary>
        /// Vietnamese Đồng
        /// </summary>
        VND,

        /// <summary>
        /// Yemeni Rial
        /// </summary>
        YER,

        /// <summary>
        /// South African Rand
        /// </summary>
        ZAR
    }
}
