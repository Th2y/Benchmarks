using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters;
using System;
using System.Collections.Generic;
using System.Linq;

[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
[HtmlExporter]
[CsvExporter]
public class PieceBenchmark
{
    private List<Piece> placedPieces;
    private HashSet<PieceType> placedTypes;

    [Params(10, 100, 1000, 10000)]
    public int Size;

    [Params(true, false)]
    public bool EarlyBreak;

    [GlobalSetup]
    public void Setup()
    {
        placedPieces = GeneratePieces(Size, EarlyBreak);
        placedTypes = new HashSet<PieceType>(placedPieces.Select(p => p.Definition.type));
    }

    [Benchmark]
    public void UsingAny()
    {
        bool hasQueen = placedPieces.Any(p => p.Definition.type == PieceType.Queen);
        bool hasRook = placedPieces.Any(p => p.Definition.type == PieceType.Rook);
        bool hasBishop = placedPieces.Any(p => p.Definition.type == PieceType.Bishop);
        bool hasKnight = placedPieces.Any(p => p.Definition.type == PieceType.Knight);
        bool hasPawn = placedPieces.Any(p => p.Definition.type == PieceType.Pawn);
    }

    [Benchmark]
    public void UsingForeach()
    {
        bool hasQueen = false, hasRook = false, hasBishop = false, hasKnight = false, hasPawn = false;

        foreach (var piece in placedPieces)
        {
            switch (piece.Definition.type)
            {
                case PieceType.Queen: hasQueen = true; break;
                case PieceType.Rook: hasRook = true; break;
                case PieceType.Bishop: hasBishop = true; break;
                case PieceType.Knight: hasKnight = true; break;
                case PieceType.Pawn: hasPawn = true; break;
            }

            if (EarlyBreak && hasQueen && hasRook && hasBishop && hasKnight && hasPawn)
                break;
        }
    }

    [Benchmark]
    public void UsingFor()
    {
        bool hasQueen = false, hasRook = false, hasBishop = false, hasKnight = false, hasPawn = false;

        for (int i = 0; i < placedPieces.Count; i++)
        {
            var type = placedPieces[i].Definition.type;

            switch (type)
            {
                case PieceType.Queen: hasQueen = true; break;
                case PieceType.Rook: hasRook = true; break;
                case PieceType.Bishop: hasBishop = true; break;
                case PieceType.Knight: hasKnight = true; break;
                case PieceType.Pawn: hasPawn = true; break;
            }

            if (EarlyBreak && hasQueen && hasRook && hasBishop && hasKnight && hasPawn)
                break;
        }
    }

    [Benchmark]
    public void UsingHashSet()
    {
        bool hasQueen = placedTypes.Contains(PieceType.Queen);
        bool hasRook = placedTypes.Contains(PieceType.Rook);
        bool hasBishop = placedTypes.Contains(PieceType.Bishop);
        bool hasKnight = placedTypes.Contains(PieceType.Knight);
        bool hasPawn = placedTypes.Contains(PieceType.Pawn);
    }

    private List<Piece> GeneratePieces(int count, bool earlyBreak)
    {
        var list = new List<Piece>();

        if (earlyBreak)
        {
            var types = (PieceType[])Enum.GetValues(typeof(PieceType));

            for (int i = 0; i < count; i++)
            {
                list.Add(new Piece
                {
                    Definition = new PieceDefinition
                    {
                        type = types[i % types.Length]
                    }
                });
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(new Piece
                {
                    Definition = new PieceDefinition
                    {
                        type = PieceType.Pawn
                    }
                });
            }
        }

        return list;
    }
}

public class Piece
{
    public PieceDefinition Definition;
}

public class PieceDefinition
{
    public PieceType type;
}

public enum PieceType
{
    Queen,
    Rook,
    Bishop,
    Knight,
    Pawn
}