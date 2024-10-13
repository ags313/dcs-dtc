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

        public LocaleAwareUnitTestBase(string locale)
        {
            this._locale = locale;
        }

        [SetUp]
        public void Setup()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(_locale);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_locale);
        }
    }
}