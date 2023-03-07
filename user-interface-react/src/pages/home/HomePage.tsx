import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import PlanningPage from '../dashboard/planning/PlanningPage';
import FullCalendar from '@fullcalendar/react';

export default function HomePage() {
  return (
    <>
      <div style={{ display: "flex" }}>
        <div style={{ width: "auto" }}>
          <Card sx={{ minWidth: 275 }}>
            <CardContent>
              <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                Créer le : dd/mm/yyy
              </Typography>
              <Typography variant="h5" component="div">
                Projet 1
              </Typography>
              <Typography sx={{ mb: 1.5 }} color="text.secondary">
              Sprint Numéro : 2
              </Typography>
              <Typography variant="body2">
                Commentaire: Lorem ipsum dolor sit amet consectetur adipisicing elit. 
                Aperiam sequi illum nobis, itaque dolor aut aliquam.
              </Typography>
            </CardContent>
            <CardActions>
              <Button size="small">Ouvrir</Button>
            </CardActions>
          </Card>
        </div>
        <div style={{ width: "25px" }}></div>
        <div style={{ width: "auto" }}>
          <Card sx={{ minWidth: 275 }}>
            <CardContent>
              <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                Créer le : dd/mm/yyy
              </Typography>
              <Typography variant="h5" component="div">
                Projet 2
              </Typography>
              <Typography sx={{ mb: 1.5 }} color="text.secondary">
                Sprint Numéro : 12
              </Typography>
              <Typography variant="body2">
                Commentaire: Lorem ipsum dolor sit amet consectetur adipisicing elit. 
                Aperiam sequi illum nobis, itaque dolor aut aliquam.
              </Typography>
            </CardContent>
            <CardActions>
              <Button size="small">Ouvrir</Button>
            </CardActions>
          </Card>
        </div>
      </div>

      <Card sx={{ 
        minWidth: 275,
        my: "25px"
      }}>
        <CardContent>
        </CardContent>
      </Card>
    </>
  );
}
