namespace Chefia.App.Common;

public class Messages
{
    #region Company
    public const string CompanyNotFound = "Empresa não encontrada.";
    public const string CompanyCNPJConflict = "Já existe uma empresa cadastrada com este CNPJ";
    public const string CompanyPhoneConflict = "Já existe uma empresa cadastrada com este telefone.";
    public const string CompanyCreated = "Empresa criada com sucesso.";
    public const string CompanyUpdated = "Empresa atualizada com sucesso.";
    #endregion

    #region User
    public const string UserNotFound = "Usuário não encontrado.";
    public const string UserEmailConflict = "Já existe um usuário cadastrado com este email.";
    public const string UserCreated = "Usuário criado com sucesso.";
    public const string UserUpdated = "Usuário atualizado com sucesso.";
    public const string UserAuthFailed = "Falha na autenticação. Verifique seu email e senha.";
    public const string UserAuthSuccess = "Autenticação bem-sucedida.";
    public const string UserAlreadyInCompany = "O usuário já pertence a uma empresa.";
    #endregion

    #region Product
    public const string ProductNotFound = "Produto não encontrado.";
    public const string ProductNameConflict = "Já existe um produto com o mesmo nome.";
    public const string ProductCreated = "Produto criado com sucesso.";
    public const string ProductUpdated = "Produto atualizado com sucesso.";
    #endregion

    #region ProductCategory
    public const string ProductCategoryNotFound = "Categoria de produto não encontrada.";
    public const string ProductCategoryAlreadyExists = "Já existe uma categoria de produto com o mesmo nome.";
    public const string ProductCategoryCreated = "Categoria de produto criada com sucesso.";
    public const string ProductCategoryUpdated = "Categoria de produto atualizada com sucesso.";
    #endregion
}
