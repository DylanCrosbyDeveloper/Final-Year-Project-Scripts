using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class GunSystem : MonoBehaviour
{
    [Header("Gun Stats")]
    public float damage = 20f;
    float damagevalue;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft, bulletsShot;


    
    float HitShot, MissShot;


    [Header("Bools")]
    bool shooting, readyToShoot, reloading;


    [Header("Reference")]
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;


    [Header("Graphics")]
    public GameObject muzzleFlash, bulletHoleGraphic;
    
    public TextMeshProUGUI text;
    float maxSliderAmount;

    [Header("Graphics")]
    public float camShakeMagnitude, camShakeDuration;
    
    

    TargetSystem targetSystem;


    [Header("Gun Stats Text")]
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI timebetweenshootingText;
    public TextMeshProUGUI spreadText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI reloadtimeText;
    public TextMeshProUGUI timebetweenshotsText;
    public TextMeshProUGUI magazinesizeText;
    public TextMeshProUGUI bulletspertapText;
    public TextMeshProUGUI allowbuttonHoldText;

   


    public void Start()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        
       

    }
    public void Update()
    {
        MyInput();

        //SetText
        text.SetText(bulletsLeft + " / " + magazineSize);

        damageText.text = "Damage: " + damage.ToString();
        timebetweenshootingText.text = "Time Between Shooting: " + timeBetweenShooting.ToString();
        spreadText.text = "Spread: " + spread.ToString();
        rangeText.text = "Range: " + range.ToString();
        reloadtimeText.text = "Reload Time: " + reloadTime.ToString();
        timebetweenshotsText.text = "Time Between Shots: " + timeBetweenShots.ToString();
        magazinesizeText.text = "Magazine Size: " + magazineSize.ToString();
        bulletspertapText.text = "Bullets Per Tap: " + bulletsPerTap.ToString();
        
        if(allowButtonHold == true)
        {
            allowbuttonHoldText.text = "Allow Button Hold: True";
        }
        if(allowButtonHold == false)
        {
            allowbuttonHoldText.text = "Allow Button Hold: False";
        }

        
        
    }
    public void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);


        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();


        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    public void Shoot()
    {
        readyToShoot = false;


        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);


        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);


        //RayCast
        GameObject flash = Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity, attackPoint);
        Destroy(flash, 0.1f);

        if (Physics.Raycast(fpsCam.transform.position, direction, out RaycastHit rayHit, range))
        {
          
         
            targetSystem = transform.GetComponent<TargetSystem>();
           
            //Debug.Log(rayHit.collider.tag);
           
            if (rayHit.collider.CompareTag("Enemy"))
            {
                TargetSystem target = rayHit.transform.GetComponent<TargetSystem>();
 
                 
                target.TakeDamage(damage);
               ;
                PercentageShots Percentage = FindAnyObjectByType<PercentageShots>();
                Percentage.Hitshot(3.25f);
                

            }

            Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal));
            


            if (rayHit.collider.CompareTag("Head"))
            {
                TargetSystem target = rayHit.transform.GetComponent<TargetSystem>();
                
            }
            if (!rayHit.collider.CompareTag("Enemy"))
            {
                TargetSystem target = rayHit.transform.GetComponent<TargetSystem>();



                if (target == null && rayHit.collider.CompareTag("Walls"))
                {
                    PercentageShots Percentage = FindAnyObjectByType<PercentageShots>();

                    Percentage.Missshot(1.25f);
                }

                
            }

      }


        bulletsLeft--;
        bulletsShot--;


        Invoke("ResetShot", timeBetweenShooting);


        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    public void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);

        AimingScript reload = GetComponent<AimingScript>();
        reload.isReloading = true;
        reload.isRecoiling = true;
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    public void SetDamage(float damage)
    {
        damagevalue = damage;
    }

    
}
