# Primeiro



Simple Idle Incremental Game

Sprints:
- 0

- 1

- 2





Sprint 0:


\*MVP\*



| Mecânica          | Descrição                                                                  | “Done quando”                       |

| ----------------- | ----------------------------------------------------------------------     | ----------------------------------- |

| \*\*Tap → +1 Gold\*\* | Clique no botão central incrementa contador                            | Gold sobe visualmente a cada clique |

| \*\*Auto-Gold\*\*     | Timer gera +X Gold/s                                                   | Contador avança sozinho sem tocar   |

| \*\*Upgrade\*\*       | Compra aumenta Auto-Gold (custo sobe exponencialmente)                 | Botão muda estado p/ “MAXED”        |

| \*\*Save/Load\*\*     | Estado persiste entre sessões (JSON em Application.persistentDataPath) | Fecha / reabre e valores mantêm-se  |

| \*\*UI mínima\*\*     | Gold total, Gold/s, botão Tap, botão Upgrade                           | Sem arte extra; só cor + texto      |





Backlog: (Estimativa 1 corresponde a 30minutos)



| Ordem     | Tarefa                                                                     | Responsável | Est.           |

| --------- | ----------------------------------------------------------------------     | ----------- | -------------- |

| 1         | Criar novo projeto 2D URP                                                  | eu          | 1              |

| 2         | Montar MainCanvas c/ quatro TextMeshProUGUI + 2 Buttons                    | eu          | 2              |

| 3         | \*\*GameManager\*\* (singleton) – referencia UI e despacha eventos         | eu          | 2              |
  
| 4         | \*\*ClickManager\*\* – OnClick → AddGold(int)                              | eu          | 1              |

| 5         | \*\*UpgradeManager\*\* – custo, nível, AddGoldPerSec                       | eu          | 3              |

| 6         | \*\*Coroutina\*\* em GameManager para Auto-Gold                            | eu          | 1              |

| 7         | \*\*Saver\*\* – Serialize/Deserialize JSON a cada 30 s e OnApplicationQuit | eu          | 3              |

| 8         | Loop de play-test + bug-fix                                                | eu          | 2              |

| Total     |                                                                            | eu          | 15             |











