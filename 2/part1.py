def getGameText(line):
    # game starts 2 chars after ':'
    gameStartIndex = line.index(':') + 2

    # ignore the \n character at the end
    return line[gameStartIndex:-1]

def getRoundsTexts(gameText):
    # games are split by semi-colon
    return gameText.split(';')

def parseNumberColour(text):
    tokens = text.strip().split(' ')
    # (number, colour)
    return (int(tokens[0]), tokens[1])

def parseRound(text):
    numberColourPairTexts = text.split(',')

    return list(map(parseNumberColour, numberColourPairTexts))

def maxPerColourForRounds(rounds):
    maxes = {
        'red': 0,
        'green': 0,
        'blue': 0
    }
    for round in rounds:
        for pair in round:
            count = pair[0]
            colour = pair[1]

            if maxes[colour] < count: 
                maxes[colour] = count

    return (maxes['red'], maxes['green'], maxes['blue'])

def getMaxCounts(line):
    gameText = getGameText(line)
    roundsTexts = getRoundsTexts(gameText)
    rounds = list(map(parseRound, roundsTexts))
    maxByColour = maxPerColourForRounds(rounds)

    return maxByColour

input = open("input.txt");
lines = input.readlines();

# 12 red cubes, 13 green cubes, and 14 blue cubes
limits = (12, 13, 14)

possibleGameIdsSum = 0
gameId = 1
for line in lines:
    maxByColour = getMaxCounts(line)
    
    if maxByColour[0] > limits[0] or maxByColour[1] > limits[1] or maxByColour[2] > limits[2]:
        print("Impossible game: " + str(gameId))
    else:
        possibleGameIdsSum += gameId

    gameId += 1

print()
print("Sum of possible game ids: " + str(possibleGameIdsSum))

