using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        bool dominoesCanBeChained = false;
        if (dominoes.Count() > 1)
            dominoesCanBeChained = CheckMatchingInManyDominoes(dominoes);
        else
            dominoesCanBeChained = CheckMatchingForSingleDomino(dominoes);

        return dominoesCanBeChained;
    }

    private static bool CheckMatchingInManyDominoes(IEnumerable<(int, int)> dominoes)
    {
        bool matchingResult = false;
        int numberOfDominoes = dominoes.Count();
        int numberOfMatchings = 0;

        foreach (var firstDomino in dominoes)
        {
            foreach (var secondDomino in dominoes)
            {
                if (firstDomino == secondDomino)
                    continue;
                if (firstDomino.Item1 == secondDomino.Item2 || firstDomino.Item1 == secondDomino.Item1 ||
                   firstDomino.Item2 == secondDomino.Item2 || firstDomino.Item2 == secondDomino.Item1)
                   numberOfMatchings++;
            }
        }
        matchingResult = (numberOfMatchings >= numberOfDominoes * 2) ? true : false;
        return matchingResult;
    }

    private static bool CheckMatchingForSingleDomino(IEnumerable<(int, int)> dominoes)
    {
        bool matchingResult = false;

        if (dominoes.Count() == 0)
            matchingResult= true;
        else if (dominoes.First().Item1 == dominoes.First().Item2)
            matchingResult = true;
        else
            matchingResult = false;

        return matchingResult;
    }
}