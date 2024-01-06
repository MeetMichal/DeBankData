import React, {useState, useEffect, Children, PropsWithChildren} from 'react';
import { Button, Grid, IconButton, Modal, Typography, useMediaQuery, useTheme } from '@mui/material';
import Box from '@mui/material/Box';
import DownlaodIcon from '@mui/icons-material/FileDownload'
import ImageIcon from '@mui/icons-material/Image'
import InfoIcon from '@mui/icons-material/Info'
import domtoimage from 'dom-to-image';
import fileDownload from "js-file-download";

export interface ChartComponentProps {
    chartId: string;
    chartTitle: string;
    helpText?: string;
    dataUrl: string;
}

export default function ChartComponent(props: PropsWithChildren<ChartComponentProps>) {
    const [openHelp, setOpenHelp] = React.useState(false);
    const theme = useTheme();
    const isDesktop = useMediaQuery(theme.breakpoints.up('sm'));
    
    const handleOpenHelp = () => setOpenHelp(true);
    const handleCloseHelp = () => setOpenHelp(false);

    const handleSaveClick = (id: string, fileName:string) => {
      domtoimage.toBlob(document.getElementById(id) as Node)
         .then(function (blob:any) {
            fileDownload(blob, fileName);
         });
    }

    return (
        <Box
        sx={{
            p: 1,
            backgroundColor: "grey.100",
            border:1, 
            borderRadius:0,
            borderColor: 'grey.400'
        }} 
        >
          <Box id={props.chartId} sx={{backgroundColor: "grey.100"}} >
            <Grid alignItems="center" container justifyContent="center">
              <Typography 
                    sx={{
                    textAlign: "center",
                    }} 
                    variant={isDesktop ? "h5" : "body1"}>
                    {props.chartTitle}
              </Typography>
              {props.helpText ? 
                <IconButton onClick={handleOpenHelp} color="primary" aria-label="about chart">
                  <InfoIcon />
                </IconButton>  
                : null
              }

            </Grid>

            {props.children}
          </Box>
          {isDesktop ? 
          <>
            <Button href={props.dataUrl} target="_blank" startIcon={<DownlaodIcon/>} sx={{borderRadius:0, marginRight:1}} variant='outlined' size="small">
                  GET DATA
            </Button>
            <Button onClick={() => handleSaveClick(props.chartId, props.chartId+".png")} startIcon={<ImageIcon/>} sx={{borderRadius:0}} variant='outlined' size="small">
                  EXPORT CHART
            </Button>
          </>
           : null
          }
          <Modal
            open={openHelp}
            onClose={handleCloseHelp}
            aria-describedby="modal-modal-description"
          >
            <Box sx={{
              position: 'absolute' as 'absolute',
              top: '50%',
              left: '50%',
              minWidth: 300,
              maxWidth: 500,
              transform: 'translate(-50%, -50%)',
              bgcolor: 'background.paper',
              border:2, 
              borderRadius:0,
              borderColor: 'grey.400',
              p: 2,
            }}>
              <Typography id="modal-modal-description" sx={{ mt: 1 }}>
                {props.helpText}
              </Typography>
            </Box>
          </Modal>
        </Box>
    );
  }