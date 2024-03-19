# 02-Hangman-cdoll
``` mermaid
classDiagram
    class HangmanGame {
	+ guessedWordText:TextMeshProUGUI
	+ infoText:TextMeshProUGUI
	+ remainingAttemptsText:TextMeshProUGUI
        + words:string[]
        + maxAttempts:int
	+ Retry:GameObject
        - secretWord:string
        - guessedWord:string
        - guessedLetters:List<char>
        - remainingAttempts:int
        - hangman:SpriteRenderer[]
        - Start():void
        - Update():void
        + RetryButton():void
        - ChooseRandomWord(): void
        - CheckLetter(char letter): void
        - UpdateUI(): void
    }
```
