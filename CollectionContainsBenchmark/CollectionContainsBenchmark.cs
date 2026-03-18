using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks.CollectionContains
{
    [MemoryDiagnoser]
    [MarkdownExporter]
    [HtmlExporter]
    public class CollectionContainsBenchmark
    {
        private List<Piece> pieces = null!;
        private HashSet<PieceType> pieceTypes = null!;

        [Params(10, 100, 1000, 10000)]
        public int CollectionSize;

        [Params(true, false)]
        public bool EnableEarlyExit;

        [GlobalSetup]
        public void Setup()
        {
            pieces = GeneratePieces(CollectionSize, EnableEarlyExit);
            pieceTypes = new HashSet<PieceType>(pieces.Select(p => p.Definition.Type));
        }

        [Benchmark]
        public void LinqAny_MultipleChecks()
        {
            bool hasQueen = pieces.Any(p => p.Definition.Type == PieceType.Queen);
            bool hasRook = pieces.Any(p => p.Definition.Type == PieceType.Rook);
            bool hasBishop = pieces.Any(p => p.Definition.Type == PieceType.Bishop);
            bool hasKnight = pieces.Any(p => p.Definition.Type == PieceType.Knight);
            bool hasPawn = pieces.Any(p => p.Definition.Type == PieceType.Pawn);
        }

        [Benchmark]
        public void Foreach_SinglePass()
        {
            bool hasQueen = false, hasRook = false, hasBishop = false, hasKnight = false, hasPawn = false;

            foreach (var piece in pieces)
            {
                switch (piece.Definition.Type)
                {
                    case PieceType.Queen: hasQueen = true; break;
                    case PieceType.Rook: hasRook = true; break;
                    case PieceType.Bishop: hasBishop = true; break;
                    case PieceType.Knight: hasKnight = true; break;
                    case PieceType.Pawn: hasPawn = true; break;
                }

                if (EnableEarlyExit && hasQueen && hasRook && hasBishop && hasKnight && hasPawn)
                    break;
            }
        }

        [Benchmark]
        public void For_SinglePass()
        {
            bool hasQueen = false, hasRook = false, hasBishop = false, hasKnight = false, hasPawn = false;

            for (int i = 0; i < pieces.Count; i++)
            {
                var type = pieces[i].Definition.Type;

                switch (type)
                {
                    case PieceType.Queen: hasQueen = true; break;
                    case PieceType.Rook: hasRook = true; break;
                    case PieceType.Bishop: hasBishop = true; break;
                    case PieceType.Knight: hasKnight = true; break;
                    case PieceType.Pawn: hasPawn = true; break;
                }

                if (EnableEarlyExit && hasQueen && hasRook && hasBishop && hasKnight && hasPawn)
                    break;
            }
        }

        [Benchmark]
        public void HashSet_ContainsLookup()
        {
            bool hasQueen = pieceTypes.Contains(PieceType.Queen);
            bool hasRook = pieceTypes.Contains(PieceType.Rook);
            bool hasBishop = pieceTypes.Contains(PieceType.Bishop);
            bool hasKnight = pieceTypes.Contains(PieceType.Knight);
            bool hasPawn = pieceTypes.Contains(PieceType.Pawn);
        }

        private List<Piece> GeneratePieces(int count, bool ensureEarlyMatch)
        {
            var list = new List<Piece>(count);

            if (ensureEarlyMatch)
            {
                var types = (PieceType[])Enum.GetValues(typeof(PieceType));

                for (int i = 0; i < count; i++)
                {
                    list.Add(new Piece
                    {
                        Definition = new PieceDefinition
                        {
                            Type = types[i % types.Length]
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
                            Type = PieceType.Pawn
                        }
                    });
                }
            }

            return list;
        }
    }

    public class Piece
    {
        public PieceDefinition Definition { get; set; } = null!;
    }

    public class PieceDefinition
    {
        public PieceType Type { get; set; }
    }

    public enum PieceType
    {
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }
}