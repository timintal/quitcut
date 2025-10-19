float Ratio = (_ImageSizeRatio.x / _ImageSizeRatio.y);

if(_ChooseDimensionParameters==0)
{
    _Width = Ratio * 0.5 * _Width;
    _Height = _Height * 0.5;
}
else
{
    _Width = Ratio * 0.5  -  (_WidthMargin/_ImageSizeRatio.x) * Ratio;
    _Height = 0.5 - (_HeightMargin/_ImageSizeRatio.y);
}

// _Height = _RectSize;
// _Width = 0.5 * Ratio - (0.5 - _Height);
