import { useEffect, useState } from "react";

//Exercícios
//1 - Resolver o problema CORS na api em C# com Minimal APIs
//2 - Como exibir uma lista no HTML

function ProdutoListar() {
  const [rua, setRua] = useState("");

  //Evento de carregamento do componente
  useEffect(() => {
    console.log("Executar algo ao carregar o componente...");
    // carregarCep();
    carregarProdutos();
  }, []);

  function carregarProdutos() {
    //FETCH ou AXIOS
    fetch("http://localhost:5076/api/produto/listar")
      .then((resposta) => resposta.json())
      .then((dados) => {
        console.log(dados);
      })
      .catch((erro) => {
        console.log("Deu erro!");
      });
  }

  function carregarCep() {
    //FETCH ou AXIOS
    fetch("https://viacep.com.br/ws/80020010/json/")
      .then((resposta) => resposta.json())
      .then((dados) => {
        setRua(dados.logradouro);
        console.log(dados.logradouro);
      })
      .catch((erro) => {
        console.log("Deu erro!");
      });
  }

  return (
    <div>
      <p>{rua}</p>
    </div>
  );
}

export default ProdutoListar;
