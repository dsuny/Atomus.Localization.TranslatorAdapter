using Atomus.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows;

namespace Atomus.Localization
{
    public class TranslatorAdapter : ITranslator
    {
        Dictionary<string, DataSet> ITranslator.Dictionary { get; set; }

        string ITranslator.SourceCultureName
        {
            get
            {
                return this.translator?.SourceCultureName;
            }
            set
            {
                if (this.translator != null)
                    this.translator.SourceCultureName = value;
            }
        }
        string ITranslator.TargetCultureName
        {
            get
            {
                return this.translator?.TargetCultureName;
            }
            set
            {
                if (this.translator != null)
                    this.translator.TargetCultureName = value; ;
            }
        }

        CultureInfo ITranslator.SourceCultureInfo
        {
            set
            {
                if (this.translator != null)
                    this.translator.SourceCultureInfo = value;
            }
        }
        CultureInfo ITranslator.TargetCultureInfo
        {
            set
            {
                if (this.translator != null)
                    this.translator.TargetCultureInfo = value;
            }
        }

        ITranslator translator;

        public TranslatorAdapter()
        {
            try
            {
                translator = (ITranslator)this.CreateInstance("Translator");
            }
            catch (AtomusException exception)
            {
                DiagnosticsTool.MyTrace(exception);
                translator = new NoneTranslator();
            }
            catch (Exception exception)
            {
                DiagnosticsTool.MyTrace(exception);
                translator = new NoneTranslator();
            }

            try
            {
                if (this.translator != null)
                    ((ITranslator)this).Dictionary = translator.Dictionary;
            }
            catch (AtomusException exception)
            {
                DiagnosticsTool.MyTrace(exception);
            }
            catch (Exception exception)
            {
                DiagnosticsTool.MyTrace(exception);
            }

            try
            {
                if (translator != null)
                    translator.SourceCultureName = this.GetAttribute("SourceCultureName");
            }
            catch (AtomusException exception)
            {
                DiagnosticsTool.MyTrace(exception);
                translator.SourceCultureName = CultureInfo.CurrentCulture.Name;
            }
            catch (Exception exception)
            {
                DiagnosticsTool.MyTrace(exception);
                translator.SourceCultureName = CultureInfo.CurrentCulture.Name;
            }
        }

        string ITranslator.Translate(string source, params string[] args)
        {
            if (this.translator != null)
                return this.translator.Translate(source, args);
            else
                return string.Format(source, args);
        }
        string ITranslator.Translate(string source, CultureInfo sourceCultureInfo, CultureInfo targetCultureInfo, params string[] args)
        {
            if (this.translator != null)
                return this.translator.Translate(source, sourceCultureInfo.Name, targetCultureInfo.Name, args);
            else
                return string.Format(source, args);
        }
        string ITranslator.Translate(string source, string sourceCultureName, string targetCultureName, params string[] args)
        {
            if (this.translator != null)
                return this.translator.Translate(source, sourceCultureName, targetCultureName, args);
            else
                return string.Format(source, args);
        }
        string[] ITranslator.Translate(string[] source, params string[][] args)
        {
            if (this.translator != null)
                return this.translator.Translate(source, args);
            else
            {
                for (int i = 0; i < source.Length; i++)
                {
                    source[i] = ((ITranslator)this).Translate(source[i], args[i]);
                }

                return source;
            }
        }
        string[] ITranslator.Translate(string[] source, CultureInfo sourceCultureInfo, CultureInfo targetCultureInfo, params string[][] args)
        {
            if (this.translator != null)
                return this.translator.Translate(source, sourceCultureInfo.Name, targetCultureInfo.Name, args);
            else
                return ((ITranslator)this).Translate(source, args);
        }
        string[] ITranslator.Translate(string[] source, string sourceCultureName, string targetCultureName, params string[][] args)
        {
            if (this.translator != null)
                return this.translator.Translate(source, sourceCultureName, targetCultureName);
            else
            {
                for (int i = 0; i < source.Length; i++)
                {
                    source[i] = ((ITranslator)this).Translate(source[i], args[i]);
                }

                return source;
            }
        }

        DataTable ITranslator.Translate(DataTable source)
        {
            if (this.translator != null)
                return this.translator.Translate(source);
            else
                return source;
        }
        DataTable ITranslator.Translate(DataTable source, CultureInfo sourceCultureInfo, CultureInfo targetCultureInfo)
        {
            if (this.translator != null)
                return this.translator.Translate(source, sourceCultureInfo.Name, targetCultureInfo.Name);
            else
                return source;
        }
        DataTable ITranslator.Translate(DataTable source, string sourceCultureName, string targetCultureName)
        {
            if (this.translator != null)
                return this.translator.Translate(source, sourceCultureName, targetCultureName);
            else
                return source;
        }
        DataSet ITranslator.Translate(DataSet source)
        {
            if (this.translator != null)
                return this.translator.Translate(source);
            else
                return source;
        }
        DataSet ITranslator.Translate(DataSet source, CultureInfo sourceCultureInfo, CultureInfo targetCultureInfo)
        {
            if (this.translator != null)
                return this.translator.Translate(source, sourceCultureInfo.Name, targetCultureInfo.Name);
            else
                return source;
        }
        DataSet ITranslator.Translate(DataSet source, string sourceCultureName, string targetCultureName)
        {
            if (this.translator != null)
                return this.translator.Translate(source, sourceCultureName, targetCultureName);
            else
                return source;
        }

        void ITranslator.Translate(System.Windows.Forms.Control control)
        {
            if (this.translator != null)
                this.translator.Translate(control);
        }
        void ITranslator.Translate(System.Windows.Forms.Control control, CultureInfo sourceCultureInfo, CultureInfo targetCultureInfo)
        {
            if (this.translator != null)
                ((ITranslator)this).Translate(control, sourceCultureInfo.Name, targetCultureInfo.Name);
        }
        void ITranslator.Translate(System.Windows.Forms.Control control, string sourceCultureName, string targetCultureName)
        {
            if (this.translator != null)
                this.translator.Translate(control, sourceCultureName, targetCultureName);
        }
        void ITranslator.Translate(System.Windows.Forms.Control.ControlCollection controls)
        {
            if (this.translator != null)
                this.translator.Translate(controls);
        }
        void ITranslator.Translate(System.Windows.Forms.Control.ControlCollection controls, CultureInfo sourceCultureInfo, CultureInfo targetCultureInfo)
        {
            if (this.translator != null)
                this.translator.Translate(controls, sourceCultureInfo, targetCultureInfo);
        }
        void ITranslator.Translate(System.Windows.Forms.Control.ControlCollection controls, string sourceCultureName, string targetCultureName)
        {
            if (this.translator != null)
                this.translator.Translate(controls, sourceCultureName, targetCultureName);
        }
        void ITranslator.Translate(System.Windows.Forms.ContainerControl containerControl)
        {
            if (this.translator != null)
                this.translator.Translate(containerControl);
        }
        void ITranslator.Translate(System.Windows.Forms.ContainerControl containerControl, CultureInfo sourceCultureInfo, CultureInfo targetCultureInfo)
        {
            if (this.translator != null)
                ((ITranslator)this).Translate(containerControl, sourceCultureInfo.Name, targetCultureInfo.Name);
        }
        void ITranslator.Translate(System.Windows.Forms.ContainerControl containerControl, string sourceCultureName, string targetCultureName)
        {
            if (this.translator != null)
                ((ITranslator)this).Translate(containerControl, sourceCultureName, targetCultureName);
        }

        void ITranslator.Restoration(System.Windows.Forms.Control control)
        {
            if (this.translator != null)
                this.translator.Restoration(control);
        }
        void ITranslator.Restoration(System.Windows.Forms.Control.ControlCollection controls)
        {
            if (this.translator != null)
                this.translator.Translate(controls);
        }
        void ITranslator.Restoration(System.Windows.Forms.ContainerControl containerControl)
        {
            if (this.translator != null)
                this.translator.Restoration(containerControl);
        }


        void ITranslator.Translate(DependencyObject dependencyObject)
        {
            if (this.translator != null)
                this.translator.Translate(dependencyObject);
        }
        void ITranslator.Translate(DependencyObject dependencyObject, CultureInfo sourceCultureInfo, CultureInfo targetCultureInfo)
        {
            if (this.translator != null)
                this.translator.Translate(dependencyObject, sourceCultureInfo, targetCultureInfo);
        }
        void ITranslator.Translate(DependencyObject dependencyObject, string sourceCultureName, string targetCultureName)
        {
            if (this.translator != null)
                this.translator.Translate(dependencyObject, sourceCultureName, targetCultureName);
        }

        void ITranslator.Restoration(DependencyObject dependencyObject)
        {
            if (this.translator != null)
                this.translator.Restoration(dependencyObject);
        }
    }
}