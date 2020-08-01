using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace Devour
{
    public class FormManager : Node2D
    {
        public enum Form
        {
            NormalWiz,
            Kwissi
        }

        FormManager firstInstance;

        PackedScene wizForm;
        WizForms formAlgorithm;

        Form currentForm;
        Form nextForm;



        public FormManager()
        {
            currentForm = Form.NormalWiz;
            nextForm = Form.NormalWiz;
        }

        public void ChangeWizForm(Wiz wiz)
        {
            ChangeFormAlgorithm(wiz);
            ChangeWizFieldsBasedOnForm(wiz);
        }

        public void ChangeFormAlgorithm(Wiz wiz)
        {
            switch (nextForm)
            {
                case Form.NormalWiz:
                    {
                        formAlgorithm = new NormalWiz(wiz);
                        ChangeFormScene("NormalWiz");
                        break;
                    }
                case Form.Kwissi:
                    {
                        formAlgorithm = new Kwissi(wiz);
                        ChangeFormScene("Kwissi");
                        break;
                    }
                default:
                    {
                        formAlgorithm = new NormalWiz(wiz);
                        ChangeFormScene("NormalWiz");
                        break;
                    }
            }
        }

        public void CreateNormalWizForm(Wiz wiz)
        {
            formAlgorithm = new NormalWiz(wiz);
            ChangeFormScene("NormalWiz");
            WizForms newForm = (WizForms)wizForm.Instance();
            wiz.AddChild(newForm);
            wiz.AnimationPlayer = newForm.AnimationPlayer;
        }

        public void ChangeWizFieldsBasedOnForm(Wiz wiz)
        {
            if(currentForm != nextForm)
            {
                WizForms newForm = (WizForms)wizForm.Instance();
                wiz.AddChild(newForm);
                wiz.AnimationPlayer = newForm.AnimationPlayer;
                RemoveForm(wiz);
            }
            
        }

        public void RemoveForm(Wiz wiz)
        {
            wiz.GetNode(currentForm.ToString()).QueueFree();
        }
        private void ChangeFormScene(string sceneName)
        {
            wizForm = (PackedScene)GD.Load($"res://Scenes/Wiz/Forms/{sceneName}.tscn");
        }


        public WizForms FormAlgorithm
        {
            get { return formAlgorithm; }
        }
        public PackedScene CurrentFormScene
        {
            get { return wizForm; }
        }
        public Form CurrentFormEnum
        {
            get { return currentForm; }
        }
        public Form NextFormEnum
        {
            get { return nextForm; }
        }

        public void ChangeNextForm(Form newNextForm)
        {
            nextForm = newNextForm;
        }
        public void ChangeCurrentForm(Form newCurrentForm)
        {
            currentForm = newCurrentForm;
        }
    }


}
