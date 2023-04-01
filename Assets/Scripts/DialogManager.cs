using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DialogManager : DDOLSingletonMonoBehaviour<DialogManager>
{
    [Header("Preset")]
    [SerializeField] private GameObject baseDialogPref;
    [SerializeField] private Canvas canvas;

    public void Show(BaseDialogData data)
    {
        BaseDialog baseDialog = Instantiate(baseDialogPref, canvas.transform).GetComponent<BaseDialog>();
        baseDialog.Build(data);
    }
}
