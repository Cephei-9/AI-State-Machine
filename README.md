# AI-State-Machine
Эту стейт машину я написал, чтобы реализовывать задачи построения AI в играх. Она усложнялась по мере усложнения требований, сейчас я бы использовал Behaviour Tree для таких задач, но написание такой стейт машины в ручную было крутым опытом.
Я пришел к модульной структуре где паттерном(стейтом) машиныы может выступать другая машина. Такой подход позволяет реализовывать весьма сложную логику.
Важной частью являются переходы(transition) так как они во много определяют гибкость стейтов 

