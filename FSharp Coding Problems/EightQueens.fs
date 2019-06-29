module EightQueens

type Row = Row of int
type Col = Col of int

type BoardCoordinate = {
    Row: int
    Col: int
}

type Piece = 
    | Rook
    | Knight
    | Bishop
    | Queen
    | King

let rookCanCapture {Row=row1; Col=col1} {Row=row2; Col=col2} = 
    row1 = row2 || col1 = col2

let knightCanCapture {Row=row1; Col=col1} {Row=row2; Col=col2} = 
    let r = abs(row1 - row2)
    let c = abs (col1 - col2)
    (r = 1 && c = 2) || (r = 2 && c = 1)

let bishopCanCapture {Row=row1; Col=col1} {Row=row2; Col=col2} = 
    abs (row1 - row2) = abs (col1 - col2)

let queenCanCapture coord1 coord2 =
    rookCanCapture coord1 coord2
    ||
    bishopCanCapture coord1 coord2

let kingCanCapture {Row=row1; Col=col1} {Row=row2; Col=col2} = 
    abs (row1 - row2) < 2 && abs (col1 - col2) < 2

let pieceCapture =
    Map.empty
        .Add(Rook, rookCanCapture)
        .Add(Knight, knightCanCapture)
        .Add(Bishop, bishopCanCapture)
        .Add(Queen, queenCanCapture)
        .Add(King, kingCanCapture)

let canCapture piece  coord1 coord2 =
    pieceCapture.[piece] coord1 coord2

