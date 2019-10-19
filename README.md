# O que é OCR?

O OCR é o processo de conversão de uma imagem para texto e, atualmente, pode ser feito por meio de diversas técnicas, com diferentes tipos de otimizações e abordagens.

<hr>

## Configurando projeto

- Primeiramente deve ser criado uma conta no site https://ocr.space
- Após criar a conta e confirma-la por email, você receberá uma api key para utilizar o serviço
- Substitua a API KEY na classe LibraryBLL
- Ajuste o diretório de leitura do arquivo(JPG,PNG ou PDF)

## Métodos disponíveis

- public static bool CompareDeepProcess(ResponseOCR ocr, string ComparedValue)
- public static bool CompareSimpleProcess(string ExtractedText, string ComparedValue)
- public static void ShowExtractedTests(ResponseOCR ocr)
