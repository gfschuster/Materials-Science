# Modelos 3D de Estruturas Cristalinas

Este repositório contém scripts que geram modelos 3D de estruturas cristalinas utilizando o **Unity 3D**. As estruturas representadas incluem:

- Cúbica Simples (CS)
- Cúbica de Corpo Centrado (CCC)
- Cúbica de Face Centrada (CFC)

## Descrição

As estruturas cristalinas são formas de arranjo atômico em sólidos que influenciam diretamente as propriedades físicas dos materiais. Este projeto visa facilitar a visualização dessas estruturas, permitindo que usuários gerem modelos 3D interativos.

O projeto utiliza o motor **Unity 3D** para a criação, manipulação e renderização das estruturas cristalinas. Cada estrutura foi modelada com base em sua disposição atômica específica:

- **Cúbica Simples (CS)**: átomos localizados nos vértices do cubo.
- **Cúbica de Corpo Centrado (CCC)**: átomos nos vértices e um átomo adicional no centro do cubo.
- **Cúbica de Face Centrada (CFC)**: átomos nos vértices e no centro de cada face do cubo.

## Estrutura do Projeto

- **Assets/**: Contém todos os arquivos de scripts e objetos 3D necessários para a criação dos modelos.
- **Library/**: Diretório gerado pelo Unity que armazena informações do projeto.
- **ProjectSettings/**: Contém as configurações do projeto Unity.
- **UserSettings/**: Configurações do usuário no projeto.
- **Logs/**: Arquivos de log do Unity.

## Como Usar

### Requisitos

- [Unity 3D](https://unity.com/) (versão 2021.3 ou superior recomendada)
- Sistema operacional compatível com Unity

### Passos

1. Clone este repositório:
   ```bash
   git clone https://github.com/gfschuster/Materials-Science
   ```

2. Abra o Unity Hub e selecione "Add Project from Disk" para adicionar o projeto à sua lista de projetos do Unity.

3. Navegue até a pasta raiz do projeto e abra o arquivo CMat.sln no Unity.

4. Execute o projeto dentro do Unity para visualizar e interagir com os modelos 3D das estruturas cristalinas.
