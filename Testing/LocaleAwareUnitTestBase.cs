using System.Globalization;

namespace Testing
{
    [TestFixture("en-US")]
    [TestFixture("en-GB")]
    [TestFixture("pl-PL")]
    [TestFixture("de-DE")]
    [TestFixture("ar_OM")]
    public abstract class LocaleAwareUnitTestBase
    {
        private readonly string _locale;
        private CultureInfo _culture;

        public LocaleAwareUnitTestBase(string locale)
        {
            this._locale = locale;
            this._culture = new CultureInfo(_locale);
        }

        [SetUp]
        public void Setup()
        {
            Thread.CurrentThread.CurrentCulture = this._culture;
            Thread.CurrentThread.CurrentUICulture = this._culture;
        }
    }
}