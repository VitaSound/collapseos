( 8K of onboard RAM )
0xdd00 CONSTANT RS_ADDR
( Memory register at the end of RAM. Must not overwrite )
0xddca CONSTANT PS_ADDR
RS_ADDR 0x80 - CONSTANT SYSVARS
0xc000 CONSTANT HERESTART
0xbf   CONSTANT TMS_CTLPORT
0xbe   CONSTANT TMS_DATAPORT
SYSVARS 0x70 + CONSTANT GRID_MEM
SYSVARS 0x73 + CONSTANT CPORT_MEM
0x3f   CONSTANT CPORT_CTL
0xdc   CONSTANT CPORT_D1
0xdd   CONSTANT CPORT_D2
SYSVARS 0x74 + CONSTANT PAD_MEM
5 LOAD  ( z80 assembler )
: ZFILL, ( u ) 0 DO 0 A, LOOP ;
262 LOAD  ( xcomp )
524 LOAD  ( font compiler )
165 LOAD  ( Sega ROM signer )
282 LOAD  ( boot.z80.decl )
270 LOAD  ( xcomp overrides )

DI, 0x100 JP, 0x62 ZFILL, ( 0x66 )
RETN, 0x98 ZFILL, ( 0x100 )
( All set, carry on! )
CURRENT @ XCURRENT !
0x100 BIN( !
283 335 LOADR ( boot.z80 )
353 LOAD  ( xcomp core low )
CREATE ~FNT CPFNT7x7
470 472 LOADR ( TMS9918 )
602 604 LOADR ( VDP )
402 404 LOADR ( Grid )
625 626 LOADR ( SMS ports )
612 617 LOADR ( PAD )
390 LOAD  ( xcomp core high )
(entry) _
( Update LATEST )
PC ORG @ 8 + !
," VDP$ GRID$ PAD$ (im1) " EOT,
ORG @ 0x100 - DUP 256 /MOD 2 PC! 2 PC!
DUP 1 ( 16K ) segasig
0x4000 + 256 /MOD 2 PC! 2 PC!
