# Basic Output

## Introduction

This is the directory where are the studies about the basic data types of the language.


## Signed & Unsigned Integral Types

The table above shows the integral data types:

<table>
    <thead>
        <th>Type</th>
        <th>Format specifiers</th>
        <th>Range constants</th>
        <th>Range</th>
        <th>Suffix for decimal constants</th>
    </thead>
    <tbody>
        <tr>
            <td>
                singleshort
                short int
                signed short
                signed short int
            </td>
            <td>%hi or %hd</td>
            <td>SHRT_MIN / SHRT_MAX</td>
            <td>−32,767, +32,767</td>
            <td></td>
        </tr>
        <tr>
            <td>
                unsigned short
                unsigned short int
            </td>
            <td>%hu</td>
            <td>0 / USHRT_MAX</td>
            <td>0, 65,535</td>
            <td></td>
        </tr>
        <tr>
            <td>
                int
                signed
                signed int
            </td>
            <td>%i or %d</td>
            <td>INT_MIN / INT_MAX</td>
            <td>−32,767, +32,767</td>
            <td></td>
        </tr>
        <tr>
            <td>
                unsigned
                unsigned int
            </td>
            <td>%u</td>
            <td>0 / UINT_MAX</td>
            <td>0, 65,535</td>
            <td>u or U</td>
        </tr>
        <tr>
            <td>
                long
                long int
                signed long
                signed long int
            </td>
            <td>%li or %ld</td>
            <td>LONG_MIN / LONG_MAX</td>
            <td>−2,147,483,647, +2,147,483,647</td>
            <td>l or L</td>
        </tr>
        <tr>
            <td>
                unsigned long
                unsigned long int 
            </td>
            <td>%lu</td>
            <td>0 / ULONG_MAX</td>
            <td>0, 4,294,967,295</td>
            <td>both u or U and l or L</td>
        </tr>
        <tr>
            <td>
                long long
                long long int
                signed long long
                signed long long int
            </td>
            <td>%lli or %lld</td>
            <td>LLONG_MIN / LLONG_MAX</td>
            <td>−9,223,372,036,854,775,807, +9,223,372,036,854,775,807</td>
            <td>ll or LL</td>
        </tr>
        <tr>
            <td>
                unsigned long long
                unsigned long long int
            </td>
            <td>%llu</td>
            <td>0 / ULLONG_MAX</td>
            <td>0, 18,446,744,073,709,551,615</td>
            <td>both u or U and ll or LL</td>
        </tr>
    </tbody>
</table>


## Floating Point Types

The table above shows the floating point data types:

<table>
    <thead>
        <th>Type</th>
        <th>Format Specifiers</th>
        <th>Range</th>
        <th>Precision</th>
        <th>Suffix for decimal constants</th>
    </thead>
    <tbody>
        <tr>
            <td>float</td>
            <td>
                %f %F
                %g %G
                %e %E
                %a %A
            </td>
            <td>±1.5 x 10^-45 to ±3.4 x 10^38</td>
            <td>7 digits</td>
            <td>f or F</td>
        </tr>
        <tr>
            <td>double</td>
            <td>
                %lf %lF
                %lg %lG
                %le %lE
                %la %lA
            </td>
            <td>±5 x 10^-324 to ±1.7 x 10^308</td>
            <td>14 digits</td>
            <td></td>
        </tr>
        <tr>
            <td>long double</td>
            <td>
                %Lf %LF
                %Lg %LG
                %Le %LE
                %La %LA
            </td>
            <td>±5 x 10^-324 to ±1.7 x 10^308</td>
            <td>18 digits</td>
            <td></td>
        </tr>
    </tbody>
</table>


## Character Types

The table above shows the character data types:

<table>
    <thead>
        <th>Type</th>
        <th>Format Specifiers</th>
        <th>Range Constants</th>
        <th>Range</th>
    </thead>
    <tbody>
        <tr>
            <td>char</td>
            <td>%c</td>
            <td>CHAR_MIN / CHAR_MAX</td>
            <td>−127, +127</td>
        </tr>
        <tr>
            <td>signed char</td>
            <td>%c (or %hhi for numerical output)</td>
            <td>SCHAR_MIN / SCHAR_MAX</td>
            <td>−127, +127</td>
        </tr>
        <tr>
            <td>unsigned char</td>
            <td>%c (or %hhu for numerical output)</td>
            <td>0 / UCHAR_MAX</td>
            <td>0, 255</td>
        </tr>
    </tbody>
</table>