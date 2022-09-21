using Bogus;
using Exemplo.Tests.Fixtures;
using Exemplo.WebApp;
using Exemplo.WebApp.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Exemplo.Tests.StepDefinitions
{

    [Binding]
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public sealed class CadastroClienteSteps

    {
        private readonly IntegrationTestsFixture<TestStartup> _testsFixture;

        private readonly ScenarioContext _scenarioContext;

        public CadastroClienteSteps(ScenarioContext scenarioContext, IntegrationTestsFixture<TestStartup> testsFixture)
        {
            _scenarioContext = scenarioContext;
            _testsFixture = testsFixture;
        }

        [Given(@"que preciso gerar um usuario cliente")]
        public void DadoQuePrecisoGerarUmUsuarioCliente()
        {
            var cliente = new Faker<Cliente>("pt_BR")
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.Nome, f => f.Person.FirstName)
                .Generate();

            _scenarioContext.Set(cliente);

        }
        [When(@"requisito API de cadastro com nome e email validos")]
        public async Task QuandoRequisitoAPIDeCadastroComNomeEEmailValidos()
        {
            var cliente = _scenarioContext.Get<Cliente>();
            var response = await _testsFixture.Client.PostAsJsonAsync("clientes", cliente);

            _scenarioContext.Add("response", response);
        }


        [Then(@"deve cadastrar com sucesso")]
        public void EntaoDeveCadastrarComSucesso()
        {
            var response = _scenarioContext.TryGetValue("response", out HttpResponseMessage message);

            Assert.Equal(HttpStatusCode.OK, message.StatusCode);
        }

    }
}
