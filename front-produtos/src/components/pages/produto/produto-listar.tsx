import { useEffect, useState } from "react";
import { Produto } from "../../../models/Produto";

//EXERCÍCIOS
//1 - Implementar o cadastro a partir do formulário
//2 - Implementar a remoção
//3 - Implementar a alteração

function ProdutoListar() {
  const [produtos, setProdutos] = useState<Produto[]>([]);
  //Evento de carregamento do componente
  useEffect(() => {
    console.log("Executar algo ao carregar o componente...");
    carregarProdutos();
  }, []);

  function carregarProdutos() {
    //FETCH ou AXIOS
    fetch("http://localhost:5076/api/produto/listar")
      .then((resposta) => resposta.json())
      .then((produtos: Produto[]) => {
        setProdutos(produtos);
        console.table(produtos);
      })
      .catch((erro) => {
        console.log("Deu erro!");
      });
  }

  function cadastrar() {
    const produto: Produto = {
      nome: "Teste APP Visual",
      descricao: "Teste APP Visual",
      preco: 147,
      quantidade: 1500,
    };
    fetch("http://localhost:5076/api/produto/cadastrar", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(produto),
    })
      .then((resposta) => resposta.json())
      .then((produtoCadastrado: Produto) => {
        console.log(produtoCadastrado);
      });
  }

  return (
    <div>
      <h1>Listar Produtos</h1>
      <table>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Desrição</th>
            <th>Preço</th>
            <th>Quantidade</th>
            <th>Criado Em</th>
          </tr>
        </thead>
        <tbody>
          {produtos.map((produto) => (
            <tr key={produto.id}>
              <td>{produto.id}</td>
              <td>{produto.nome}</td>
              <td>{produto.descricao}</td>
              <td>{produto.preco}</td>
              <td>{produto.quantidade}</td>
              <td>{produto.criadoEm}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <button onClick={cadastrar}>Cadastrar</button>
    </div>
  );
}

export default ProdutoListar;
