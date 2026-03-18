# Validando o Big-O no C#

Este repositório contém benchmarks comparando diferentes abordagens para verificar a existência de elementos em coleções, usando C# e BenchmarkDotNet.

O objetivo é analisar como a complexidade assintótica (**Big-O**) se comporta na prática — e até onde ela pode ser enganosa.

---

## 🎯 Problema

Dado um conjunto de peças já utilizadas, precisamos verificar rapidamente se certos tipos já foram usados.

Exemplo real: lógica de decisão para IA em um jogo de xadrez.

---

## 🔬 Abordagens testadas

* LINQ (`Any`)
* `foreach`
* `for`
* `HashSet`

---

## 📊 Complexidade esperada

| Abordagem | Complexidade |
| --------- | ------------ |
| HashSet   | O(1)         |
| foreach   | O(n)         |
| for       | O(n)         |
| Any       | O(n)         |

👉 Em teoria, `HashSet` deveria ser o mais rápido.

---

## 🧪 Cenários testados

Os benchmarks foram executados considerando:

* Tamanhos de lista: `10`, `100`, `1000`, `10000`
* Dois cenários:

  * 🔴 **Sem early break** (pior caso)
  * 🟢 **Com early break** (melhor caso)

---

## 📈 Resultados

👉 Veja o relatório completo formatado para GitHub:
📄 [Benchmark completo](./docs/benchmarks.md)

---

## ⚡ Principais insights

### 🔴 Sem early break (pior caso)

* `HashSet` mantém tempo constante (~6 ns)
* `foreach` e `for` crescem linearmente
* `LINQ (Any)` é o mais lento (overhead + múltiplas iterações)

👉 Aqui o Big-O se confirma perfeitamente.

---

### 🟢 Com early break (melhor caso)

* `foreach` e `for` se tornam os mais rápidos (~6 ns)
* `HashSet` fica mais lento (~9–10 ns)
* `LINQ` continua o mais lento (~26 ns)

👉 **O(n) foi mais rápido que O(1)**

---

## 🧠 Conclusões

* Big-O mede crescimento, não tempo real
* Overhead constante pode superar complexidade assintótica
* Early exit pode reduzir drasticamente o custo real
* LINQ é expressivo, mas tem custo
* Estruturas como `HashSet` brilham em grandes volumes

---

## ⚠️ Ambiente de execução

```
BenchmarkDotNet v0.15.8
Windows 11
Intel i5-11400H (6 cores / 12 threads)
.NET 10
RyuJIT x64
```

> ⚠️ Os resultados podem variar dependendo do hardware e da versão do runtime.

---

## 🚀 Como executar

```bash
dotnet run -c Release
```

> ⚠️ Execute sempre em modo **Release** para resultados confiáveis.

---

## 💡 Motivação

Existe uma ideia comum de que:

> “O(1) sempre é mais rápido que O(n)”

Este projeto mostra que isso **nem sempre é verdade na prática**.

---

## 📚 Tecnologias utilizadas

* C#
* .NET 10
* BenchmarkDotNet

---

## 📌 Conclusão final

> Teoria é essencial.
> Mas performance real só se prova com benchmark.

---

Se esse tipo de análise te interessa, fique à vontade para explorar, testar e contribuir 🚀
