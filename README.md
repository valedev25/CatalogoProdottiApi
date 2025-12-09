# Catalogo Prodotti API

API REST per la gestione di un catalogo di prodotti, sviluppata in **.NET 8** con ASP.NET Core Web API e Entity Framework Core InMemory.

## Tecnologie utilizzate

- **.NET 8** con C#
- **ASP.NET Core Web API**
- **Entity Framework Core InMemory**
- **Swagger**


## Come avviare il progetto

1. Clona il repository:

```bash
git clone <https://github.com/valedev25/CatalogoProdottiApi.git>
cd CatalogoProdottiApi
```

2. Ripristina i pacchetti:

```bash
dotnet restore
```

3. Avvia l’API:

```bash
dotnet run
```

4. Apri **Swagger**:

```
https://localhost:7141/swagger
```

5. Testa gli endpoint con Swagger


## Scelte architetturali
- **SOLID e OOP**
- **Separazione in livelli**
- Controller → Service → Repository → DbContext  (separazione delle responsabilità (SRP))
Ho cercato di semplificare la soluzione rispettano le direttive.

- **Pattern Repository**
  Separazione tra logica di business e accesso ai dati.
- **Dependency Injection**
  Registrazione di repository e service nel container DI
- **DTO**
  Separazione entità di dominio da input/output API
- **Eccezioni personalizzate**
- **Middleware globale eccezioni** 
   Per centralizzare error handling e status code
- **EF Core InMemory** 
   Permette testing e sviluppo locale
-  **Swagger** 
   Test endpoints
- **GitHub**
   Utilizzo di GitHub per controllo del versionamento, dei vari ambienti di sviluppo(ad esempio Master, Develop, Test) e l’evoluzione del progetto.


## Miglioramenti futuri

- Aggiungere Token Jwt autenticazione e autorizzazione 
- Aggiungere database SQL Server  
- Implementare unit test e integration test  
- Aggiungere log centralizzato  
- Per la struttura del progetto in un contesto più grande, o di business, che richiedeva la gestione di molti più dati, servizi e più compiti, opterei per una struttura a più layer con delle librerie a supporto dell'api. Cioè dividerei la soluzione in:

- CatalogoProdottiApi(progetto principale)
   - Settings
   - Controller
   - Middleware
- CatalogoProdottiApi.Data (libreria .Net)
   - DbContext 
   - Repository
- CatalogoProdottiApi.Domain (libreria .Net)
   - Entità
   - Interfacce
- CatalogoProdottiApi.Service (libreria .Net)
   - Servizio


## Entità Prodotto

| Campo     | Tipo    | Descrizione                  |
|----------|--------|------------------------------|
| Id       | GUID   | Id      |
| Nome     | string | Nome del prodotto            |
| Prezzo   | decimal| Prezzo del prodotto          |
| Categoria| string | Categoria del prodotto       |

## Documentazione API
## Endpoints

| Metodo | Endpoint | Request Body | Descrizione | Response |
|--------|---------|--------------|------------|---------|
| GET    | /api/prodotti         | —                  | Recupera tutti i prodotti              | 200 OK — Lista di ProdottoResponseDto |
| GET    | /api/prodotti/{id}    | —                  | Recupera prodotto per ID              | 200 OK — ProdottoResponseDto |
| POST   | /api/prodotti         | ProdottoCUDto      | Crea un nuovo prodotto                | 201 Created — ProdottoResponseDto |
| PUT    | /api/prodotti/{id}    | ProdottoCUDto      | Aggiorna un prodotto esistente       | 204 NoContent |
| DELETE | /api/prodotti/{id}    | —                  | Elimina un prodotto                   | 204 NoContent |


## DTO

### `ProdottoCUDto` — Create/Update

```json
{
  "nome": "string",
  "prezzo": 0,
  "categoria": "string"
}
```

### `ProdottoResponseDto` — Output

```json
{
  "id": "GUID",
  "nome": "string",
  "prezzo": 0,
  "categoria": "string"
}
