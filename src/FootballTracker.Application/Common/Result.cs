namespace FootballTracker.Application.Common;
/*📌 Por que isso existe?

Porque:

Application não deve lançar exceção de fluxo

Controllers (futuro) precisam saber se deu certo ou não

Mensagem de erro não é exceção

Simples

Sem generics por enquanto

Sem lista de erros

Sem enum de código
 
 */

public class Result
{
    public bool IsSuccess { get; }
    public string? Error { get; }

    protected Result(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success()
        => new Result(true, null);

    public static Result Failure(string error)
        => new Result(false, error);
}
